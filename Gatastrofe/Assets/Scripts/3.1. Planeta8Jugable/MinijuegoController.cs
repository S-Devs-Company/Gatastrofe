using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinijuegoController : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && EventManager.ValidarEvento("PMJ-32-00"))
        {
            SceneManagerScript.CargarEscena("Scenes/3.2. MinijuegoPlaneta8");
        }
    }
}
