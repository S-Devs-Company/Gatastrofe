using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MinijuegoPlaneta7Controller : MonoBehaviour
{
    [SerializeField] Slider barraDeProgreso;
    [SerializeField] TextMeshProUGUI tiempoRestante;
    [SerializeField] TextMeshProUGUI textoVidas;
    private const float tiempoMinijuego = 60;
    private float timer;
    private const int vidasMax = 3;
    public static int vidasGastadas;
    // Start is called before the first frame update
    void Start()
    {
        vidasGastadas = 0;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        tiempoRestante.text = "Lluvia de meteoritos acaba en "+Convert.ToInt64(tiempoMinijuego - timer).ToString()+"s";
        textoVidas.text = "Vidas restantes " + (vidasGastadas - vidasMax) + "/3";
        barraDeProgreso.value = (tiempoMinijuego - timer) / tiempoMinijuego;
        if (timer > tiempoMinijuego)
        {
            EventManager.ModificarEstadoEvento("PFJ-42-00", 1);
            SceneManagerScript.CargarEscena("Scenes/4.1. Planeta7Jugable");
        }
        if (vidasGastadas >= vidasMax)
        {
            SceneManagerScript.CargarEscena("Scenes/4.1. Planeta7Jugable");
        }
    }

    public static void Choque()
    {
        vidasGastadas++;
    }
}
