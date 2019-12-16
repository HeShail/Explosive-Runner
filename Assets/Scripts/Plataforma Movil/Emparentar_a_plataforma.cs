using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emparentar_a_plataforma : MonoBehaviour
{


    private GameObject padre;
    public GameObject player;

    private void Start()
    {
        padre = new GameObject();
        //Activamos y desactivamos el GameObject siempre que lo usamos, para no crear multitud de ellos.
        padre.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if  (other.gameObject == player)
        {
            padre.SetActive(true);
            padre.transform.parent = transform;
            player.transform.parent = padre.transform;
            
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = null;
            padre.SetActive(false);
        }
    }
}
