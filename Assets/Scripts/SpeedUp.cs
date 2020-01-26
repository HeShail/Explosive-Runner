using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SpeedUp : MonoBehaviour
{

    //Activa la función de aumento de velocidad en FP Controller
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.GetComponent<FirstPersonController>().SetBoost();
            Destroy(gameObject);
        }
    }
}
