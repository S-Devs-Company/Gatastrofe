using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionEstructuras : MonoBehaviour
{
    public GameObject player;

    private void OnCollisionEnter(Collision jugador)
    {
        if (jugador.collider.CompareTag("Player"))
        {
            Playable.velocidad = -Playable.velocidad;
            
        }
    }

    private void OnCollisionExit(Collision jugador)
    {
        if (jugador.collider.CompareTag("Player"))
        {
            Playable.velocidad = 5;
        }
    }

}
