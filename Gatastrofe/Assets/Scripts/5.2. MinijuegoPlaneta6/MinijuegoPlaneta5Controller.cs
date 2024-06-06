using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinijuegoPlaneta5Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Casas").Length == 3)
        {
            EventManager.ModificarEstadoEvento("PGJ-63-00",1);
            SceneManagerScript.CargarEscena("Scenes/5.1. Planeta6Jugable");
        }
    }
}
