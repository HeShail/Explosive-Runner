using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{

    private GameObject temporizador;
    private float tiempoCambioEscena;
    private float t;
    private float temporizadorNivel = 80f;
    private TextMeshProUGUI textoContrarreloj;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TemporizadorContrarreloj();
    }

    //Método que controla el contador contrarreloj del juego y la UI.
    private void TemporizadorContrarreloj()
    {
        startTime += Time.deltaTime;
        temporizador = GameObject.Find("Temporizador");
        textoContrarreloj = temporizador.GetComponent<TextMeshProUGUI>();
        t = temporizadorNivel - startTime;


        if (t <= 0f)
        {
            string minutos = 0.ToString();
            string segundos = 0.ToString();
            textoContrarreloj.text = minutos + ":" + segundos;
            //SceneManager.LoadScene(3);

        }
        else
        {
            string minutos = ((int)t / 60).ToString();
            string segundos = ((int)t % 60).ToString();
            textoContrarreloj.text = minutos + ":" + segundos;
        }
    }

}
