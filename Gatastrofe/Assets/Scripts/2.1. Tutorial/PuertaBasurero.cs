using TMPro;
using UnityEngine;

public class PuertaBasurero : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI instrucciones;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameObject.FindGameObjectsWithTag("Pick").Length == 0)
            {
                EventManager.ModificarEstadoEvento("INI-22-00", 1);
                SceneManagerScript.CargarEscena("Scenes/2.1. PlanetaTierraTutorial");
                Playable.canPlay = false;
            }
            else
            {
                instrucciones.text = "Todavía faltan piezas por recoger";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        instrucciones.text = "- Busca todas las piezas para construir tu nave.\r\n\r\n-Presiona 'E' para recogerlas.";
    }

}
