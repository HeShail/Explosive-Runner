using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateDiabolicElement : MonoBehaviour
{
    public GameObject enemyPrefab;
    public EnemyPoolManager poolScript;
    private bool activado;

    void Start()
    {
        activado = false;
    }


    public void Discharge()
    {
        poolScript.GetEnemyFromPool(gameObject.transform.GetChild(0).position, Quaternion.identity);
        
    }


    private void OnTriggerExit(Collider other)
    {
        if (!activado)
        {
            activado = true;
            Discharge();
        }

    }


}
