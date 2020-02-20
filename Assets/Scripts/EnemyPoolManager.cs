using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPoolManager : MonoBehaviour
{
    public GameObject terroristPrefab;
    public int poolSize = 3;
    private Queue<GameObject> enemyPool;


    //Inicializamos el pool y llenamos la alberca en base al tamaño, y los desactivamos, para más tarde darles uso.
    void Start()
    {
        enemyPool = new Queue<GameObject>();

        for (int i=0; i< poolSize; i++)
        {
            GameObject newEnemy = Instantiate(terroristPrefab);
            enemyPool.Enqueue(newEnemy);
            newEnemy.SetActive(false);

        }
    }

    //Extraemos y activamos el primer gameobject de la cola con la posición y rotación indicadas. Activamos el comportamiento del asset enemigo.
    public GameObject GetEnemyFromPool(Vector3 newPosition, Quaternion newRotation)
    {
        GameObject newEnemy = enemyPool.Dequeue();
        newEnemy.GetComponent<NavMeshAgent>().Warp(newPosition);
        newEnemy.transform.rotation = newRotation;
        newEnemy.GetComponent<EnemyController>().ActivarEnemigo();
        
        newEnemy.SetActive(true);
        newEnemy.transform.SetPositionAndRotation(newPosition, newRotation);
        return newEnemy;
    }

    //Devolvemos el prefab al pool y lo desactivamos.
    public void ReturnEnemyToPool(GameObject enemy)
    {
        enemy.SetActive(false);
        enemyPool.Enqueue(enemy);
    }

  
}
