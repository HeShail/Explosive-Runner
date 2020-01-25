using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Gancho : MonoBehaviour
{
    public float radioEsfera=3;
    public float distMax;
    public LayerMask layer;
    private Vector3 origin;
    private float currentDist;
    [SerializeField]
    private bool enganchado;
    [SerializeField]
    private Vector3 childPos;
    private Vector3 nuevaPosicion;
    private float fraction;
    [SerializeField]
    private CharacterController controlPadre;
    private FirstPersonController fpc;
    private LineRenderer LR;
    private float grapCool;

    void Start()
    {
        enganchado = false;
        nuevaPosicion = GetComponentInParent<FirstPersonController>().transform.position;
        controlPadre = GetComponentInParent<CharacterController>();
        fpc = GetComponentInParent<FirstPersonController>();
        LR = GetComponentInParent<LineRenderer>();
        LR.enabled = false;
        grapCool = 0;
        
    }
    

    void Update()
    {

        //Consultamos el tiempo de enfriamiento del gancho para poder usarlo (así prevenimos fallos de colisiones en el punto de enganche).
        if (grapCool < 0f)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                origin = GetComponentInParent<CharacterController>().transform.position;
                RaycastHit hit;
                if (Physics.SphereCast(origin, radioEsfera, transform.forward, out hit, distMax, layer))
                {
                    currentDist = hit.distance;
                    childPos = hit.transform.GetChild(0).position;
                    enganchado = true;
                    fpc.canMove = false;
                    controlPadre.enabled = false;
                    LR.enabled = true;
                    LR.SetPosition(0, hit.transform.position);
                    
                }
                else { enganchado = false; }


                grapCool = 1f;
            }
        }
        
       //Si consigue impactar con un objeto con máscara/layer "gancho" comienza el impulso al personaje mediante un Lerp dirigido. 
        if (enganchado==true)
        {



            //personaje.transform.position = Vector3.Lerp(personaje.transform.position, childPos, 0.3f* Time.deltaTime);
            GetComponentInParent<CharacterController>().transform.position = Vector3.Lerp(GetComponentInParent<CharacterController>().transform.position, childPos, 0.1f );
            

        }

       //Si se encuentra a la distancia de una unidad con el elemento de enganche, finaliza el trayecto y se desbloquean los controladores de "FPController" y "Character Controller". 
       //canMove es un boolean creado en el script FPController con la finalidad de intervenir en la actividad del controlador y así permitirnos movernos con el gancho sin procedimientos paralelos disruptores.
        if (Vector3.Distance(GetComponentInParent<CharacterController>().transform.position, childPos) <= 1f)
        {
            enganchado = false;
            fpc.canMove = true;
            controlPadre.enabled = true;
            LR.enabled = false;
        }

        grapCool -= Time.deltaTime;
    }
    
    //Ayuda para visualizar las interacciones del gancho en el editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(origin, origin + transform.forward * currentDist);
        Gizmos.DrawWireSphere(origin + transform.forward * currentDist, radioEsfera);
    }

}
