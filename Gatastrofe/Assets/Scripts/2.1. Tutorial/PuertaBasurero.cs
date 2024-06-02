using UnityEngine;

public class PuertaBasurero : MonoBehaviour
{
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
                //Mostrar aviso en el HUD de que todavía faltan partes de la nave
                Debug.Log("Faltan partes de la nave.");
            }
        }
    }
}
