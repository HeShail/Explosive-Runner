using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockRespawn : MonoBehaviour
{
    public Transform respawn;
    private void OnTriggerEnter(Collider other)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Respawner>().SetRespawn(respawn);
    }
}
