using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlatformBehaviour : MonoBehaviour
{
    //Activa el respawn al caer en una zona explosiva o de daño por caída/suicidio.
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player") GameObject.FindGameObjectWithTag("Player").GetComponent<Respawner>().Respawnear();
    }
}
