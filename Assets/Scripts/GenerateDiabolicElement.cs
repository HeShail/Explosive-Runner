using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateDiabolicElement : MonoBehaviour
{
    public GameObject enemyPrefab;
    private bool activado;

    void Start()
    {
        activado = false;
    }


    public void Discharge()
    {
        Instantiate(enemyPrefab, this.gameObject.transform.GetChild(0).position, Quaternion.identity);
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
