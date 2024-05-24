using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColisionReserva : MonoBehaviour
{
    public GameObject player;
    private GameObject[] RpList = new GameObject[5];

    private void Start()
    {
        for (int i = 0; i < RpList.Length; i++)
        {
            //Obtener los puntos de reset
            RpList[i] = GameObject.Find("Rp" + (i+1));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            //Mover al jugador al punto de reset más cercano
            player.transform.position = MenorDistancia(collision.collider.gameObject,RpList).transform.position;
        }
    }

    public GameObject MenorDistancia(GameObject puntoA, GameObject[] puntosB)
    {
        GameObject puntoMin = puntosB[0];
        double distanciaMin = Distancia(puntoA, puntoMin);

        for (int i = 0;i < puntosB.Length; i++)
        {
            if (Distancia(puntoA, puntosB[i]) <= distanciaMin)
            {
                puntoMin = puntosB[i];
                distanciaMin = Distancia(puntoA, puntoMin);
            }
        }

        return puntoMin;
    }

    public double Distancia (GameObject puntoA, GameObject puntoB)
    {
        return Mathf.Sqrt(Mathf.Pow((puntoA.transform.position.x - puntoB.transform.position.x), 2) + Mathf.Pow((puntoA.transform.position.y - puntoB.transform.position.y), 2) + Mathf.Pow((puntoA.transform.position.z - puntoB.transform.position.z), 2));
    }
}
