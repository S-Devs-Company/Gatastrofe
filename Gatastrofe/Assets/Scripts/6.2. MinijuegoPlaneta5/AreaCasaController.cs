using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCasaController : MonoBehaviour
{
    [SerializeField] GameObject casa;
    [SerializeField] AreaEliminadorController areaEliminadorController;
    float tiempoTocando;
    float tiempoMaximoTocando = 3;
    bool isTouching;
    // Start is called before the first frame update
    void Start()
    {
        tiempoTocando = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouching) { 
            tiempoTocando += Time.deltaTime;
            if (tiempoTocando > tiempoMaximoTocando)
            {
                Vector3 posicion = transform.position;
                Instantiate(casa,posicion,casa.transform.rotation);
                tiempoTocando = 0;
                isTouching = false;
                areaEliminadorController.setFull(true);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isTouching = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isTouching = false;
    }
}
