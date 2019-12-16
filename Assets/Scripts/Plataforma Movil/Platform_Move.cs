using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Move : MonoBehaviour
{

    public float distanciaX;
    public float distanciaY;
    public float distanciaZ;
    private Vector3 copiaPosicion;
    private Vector3 destino;
    private Vector3 posicionInicial;
    private bool isWaiting;
    public float TIEMPO_ESPERA= 3f;
    void Start()
    {

        destino = new Vector3(transform.position.x + distanciaX, transform.position.y + distanciaY, transform.position.z + distanciaZ);
        posicionInicial = transform.position;
        isWaiting = true;
        StartCoroutine("Espera");
    }

    void Update()
    {
        if (isWaiting ==false) transform.position = Vector3.MoveTowards(transform.position, destino, 0.1f);

        if ((transform.position == destino) && (posicionInicial != destino) && (isWaiting == false)){
            isWaiting = true;
            CambioSentido();
            StartCoroutine("Espera");
        }

    }

    void CambioSentido()
    {
        copiaPosicion = posicionInicial;
        posicionInicial = destino;
        destino = copiaPosicion;
    }
    
    IEnumerator Espera()
    {
        yield return new WaitForSeconds(TIEMPO_ESPERA);
        isWaiting = false;
    }
    
}
