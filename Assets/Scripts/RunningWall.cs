using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class RunningWall : MonoBehaviour
{
    [SerializeField] private bool llegar;
    [SerializeField]private bool activar;
    [SerializeField] private GameObject pj;
    private void Start()
    {
        llegar = false;
        activar = false;
    }

    private void Update()
    {
        if (activar) pj.GetComponent<CharacterController>().Move(0.2f *Vector3.forward);

    }

    //Desbloquea el control sobre la gravedad al salir del trigger y restablece las variables globales.
    private void OnTriggerExit(Collider other)
    {
        
        if (other.transform.tag == "Player")
        {
            other.GetComponent<FirstPersonController>().canMove = true;
            other.GetComponent<Rigidbody>().useGravity = true;
            activar = false;
            llegar = false;

        }
    }

    //Si el jugador dentro del trigger pulsa dos veces la tecla Space, bloquea la gravedad y avanza a través de la pared; 
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (llegar)
                {
                    other.GetComponent<FirstPersonController>().canMove = false;
                    other.GetComponent<Rigidbody>().useGravity = false;
                    activar = true;
                    pj = other.gameObject;
                }
                else
                {

                    llegar = true;
                }


            }
        }



    }

    }
