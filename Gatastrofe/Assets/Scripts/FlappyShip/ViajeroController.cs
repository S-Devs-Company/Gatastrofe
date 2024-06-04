using UnityEngine;
using UnityEngine.UI;

public class ViajeroController : MonoBehaviour
{
    [SerializeField] public static string planetaDestino;
    [SerializeField] Slider barraDeProgreso;
    float temporizador;
    // Start is called before the first frame update
    void Start()
    {
        temporizador = 0;
    }

    // Update is called once per frame
    void Update()
    {
        temporizador += Time.deltaTime;

        barraDeProgreso.value = temporizador / 12f;
        if (temporizador > 12f)
        {
            SceneManagerScript.CargarEscena(planetaDestino);
            Playable.canFly = true;
        }
    }
}
