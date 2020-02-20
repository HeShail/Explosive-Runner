using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

public class EnemyController : MonoBehaviour
{
    public GameObject explosionPrefab;
    private EnemyPoolManager poolScript;
    private Transform target;
    public NavMeshAgent agent=null;
    private float radius = 10;
    public float time;
    [SerializeField]private bool activado;
    
    // Update is called once per frame
    void Update()
    {
        poolScript = GameObject.Find("GameManager").GetComponent<EnemyPoolManager>();
        if (activado)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            if (Vector3.Distance(transform.position, target.position) <= 2f)
            {

                Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
                target.GetComponent<Respawner>().Invoke("Respawnear", 1f);
                DesactivarEnemigo();
            }
            if ((target.gameObject.activeSelf == true) && (agent.enabled == true)) agent.destination = target.position;

            //Condiciones de muerte
            if (Vector3.Distance(transform.position, target.position) >= 30f) DesactivarEnemigo();


            time += Time.deltaTime;

            if (time >= 10f) DesactivarEnemigo();
        }
        
    }

    //Función que restablece los valores predeterminados del gameobject enemigo que se utiliza en el pool.
    //Entre otros es importante el hecho de desactivar el navigator mesh agent para que no intente buscar objetivo destino mientras el enemigo está desactivado en el pool.
    public void DesactivarEnemigo()
    {
        activado = false;
        agent.enabled = false;
        time = 0f;
        poolScript.ReturnEnemyToPool(gameObject);
    }

    //Función que activa el comportamiento del enemigo tras activarse mediante el pool. 
    public void ActivarEnemigo()
    {

        activado = true;
        agent.enabled = true;

        agent = GetComponent<NavMeshAgent>();
        time = 0.0f;
        
    }
}
