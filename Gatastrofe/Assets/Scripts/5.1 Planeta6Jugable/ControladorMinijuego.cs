using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorMinijuego : MonoBehaviour
{
    [SerializeField] private GameObject PanelInstrucciones;

    private void OnTriggerEnter(Collider other)
    {
        if (EventManager.ValidarEvento("PEJ-52-00"))
        {
            PanelInstrucciones.SetActive(true);
        }
    }
}
