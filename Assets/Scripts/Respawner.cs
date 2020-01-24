using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Respawner : MonoBehaviour
{
    private Transform respawnActual;
    public GameObject fundido;
    private float temp;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        respawnActual = GameObject.Find("Respawn0").transform;
    }

    // Update is called once per frame
    void Update()
    {
    }

    //Activa la animación de fundido del canvas e invoca en un tiempo determinado la función para trasladar la posición del jugador. 
    public void Respawnear()
    {
        fundido.GetComponent<Animator>().SetTrigger("respawn");
        Invoke("Relocate", 1.5f);
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<FirstPersonController>().canMove = false;
    }

    //Traslada al jugador a su último respawn y libera el bloqueo del controlador.
    private void Relocate()
    {
        player.transform.position = respawnActual.position;
        player.GetComponent<CharacterController>().enabled = true;
        player.GetComponent<FirstPersonController>().canMove = true;
    }
}
