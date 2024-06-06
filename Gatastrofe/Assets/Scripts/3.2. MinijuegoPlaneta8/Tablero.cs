using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Tablero : MonoBehaviour
{
    // Elementos del tablero en la vista
    public Ecuacion ecuacion1;
    public Ecuacion ecuacion2;
    public Ecuacion ecuacion3;
    public Ecuacion ecuacion4;
    public Teclado teclado;
    public TextMeshProUGUI intentosTexto;

    // Lista donde se guardan las ecuaciones del tablero
    public ListaDobleEnlazada ecuaciones;

    private int intentos;

    // Start is called before the first frame update
    void Start()
    {
        intentos = 1;
        ecuaciones = new ListaDobleEnlazada();
        GenerarTablero();
        GenerarTeclado();

    }

    // Update is called once per frame
    void Update()
    {
        intentosTexto.text = intentos + "/3";
    }

    // Metodo para generar las ecuaciones del tablero y mostrarlas
    public void GenerarTablero()
    {
        ecuaciones.AgregarElemento(ecuacion1);
        ecuaciones.AgregarElemento(ecuacion2);
        ecuaciones.AgregarElemento(ecuacion3);
        ecuaciones.AgregarElemento(ecuacion4);
        for (int i = 1; i <= 4; i++)
        {
            GetEcuacion(i).GenerarEcuacion();
            GetEcuacion(i).MostrarEcuacion();
        }
    }

    // Función para obtener una ecuación de la lista
    public Ecuacion GetEcuacion(int index)
    {
        return ecuaciones.GetElemento(index).GetDato();
    }

    // Función para resolver las ecuaciones del tablero
    public bool ResolverTablero()
    {
        if (GetEcuacion(1).Resolver())
        {
            if (GetEcuacion(2).Resolver())
            {
                if (GetEcuacion(3).Resolver())
                {
                    if (GetEcuacion(4).Resolver())
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public void IntentarResolver()
    {
        if (intentos < 3)
        {
            if (ResolverTablero())
            {
                EventManager.ModificarEstadoEvento("PMJ-32-00", 1);
                EventManager.ModificarEstadoEvento("NAV-41-00", 1);
                SceneManagerScript.CargarEscena("Scenes/3.1. Planeta8Jugable");
                PlayerSpawnerController.intentoMinijuego = true;
            }
            else
            {
                intentos++;
            }
        }
        else
        {
            SceneManagerScript.CargarEscena("Scenes/3.1. Planeta8Jugable");
            PlayerSpawnerController.intentoMinijuego = true;
        }
    }

    // Metodo para pintar el tablero dependiendo de si se resolvieron las ecuaciones o no
    public void PintarTablero()
    {
        for (int i = 1; i <= 4; i++)
        {
            GetEcuacion(i).PintarEcuacion();
        }
    }

    // Metodo para generar el teclado de opciones con las ecuaciones
    public void GenerarTeclado()
    {
        List<string> textoTeclado = new List<string>();
        HashSet<string> opcionesTeclado = new HashSet<string>();
        List<char> posiblesOpciones = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '-', 'X', '/' };
        List<string> incognitas = new List<string>();
        for (int i = 1; i <= 4; i++)
        {
            incognitas.Add(GetEcuacion(i).GetValorIncongnita());
        }
        foreach (string valor in incognitas)
        {
            opcionesTeclado.Add(valor);
        }

        System.Random random = new System.Random();

        while (opcionesTeclado.Count < 10)
        {
            char opcionAleatoria = posiblesOpciones[random.Next(posiblesOpciones.Count)];
            opcionesTeclado.Add(Convert.ToString(opcionAleatoria));
        }
        textoTeclado = opcionesTeclado.ToList();
        textoTeclado = textoTeclado.OrderBy(item => random.Next()).ToList();
        teclado.GenerarTeclado(textoTeclado);
    }

}
