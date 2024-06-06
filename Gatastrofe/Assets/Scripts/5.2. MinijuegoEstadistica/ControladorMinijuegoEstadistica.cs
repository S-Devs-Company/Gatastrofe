using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorMinijuegoEstadistica : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EventManager.ModificarEstadoEvento("PEJ-52-00", 1);
            SceneManagerScript.CargarEscena("Scenes/5.1. Planeta6Jugable");
        }
    }
}
