using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnlockRespawn : MonoBehaviour
{
    public Slider barraProgreso;
    public GameObject victoria;
    private GameManager GM;
    private Transform respawn;
    private bool active;
    private void Start()
    {
        barraProgreso.minValue = 0;
        barraProgreso.maxValue = 100;
        barraProgreso.value = 0;
        respawn = this.gameObject.transform.GetChild(0);
        active = false;
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!active)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Respawner>().SetRespawn(respawn);
            barraProgreso.value += 25;
            active = true;
        }
        
    }

    private void Update()
    {
        if (barraProgreso.value >= 100)
        {
            victoria.GetComponent<TextMeshProUGUI>().text = "VICTORIA";
            victoria.GetComponent<Animator>().SetTrigger("aparecer");
            GM.Invoke("ReloadScene", 3f);
        }
    }
    
}
