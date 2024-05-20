using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tablero : MonoBehaviour
{
    public Ecuacion ecuacion1;
    public Ecuacion ecuacion2;
    public Ecuacion ecuacion3;
    public Ecuacion ecuacion4;
    public Teclado teclado;

    public ListaDobleEnlazada ecuaciones;



    public Tablero()
    {
        ecuaciones = new ListaDobleEnlazada();
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerarTablero();
        GenerarTeclado();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

    public Ecuacion GetEcuacion(int index)
    {
        return ecuaciones.GetElemento(index).GetDato();
    }

    public string[][] MostrarTablero()
    {
        string[][] tablero = new string[4][];
        for (int i = 1; i <= 4; i++)
        {
            tablero[i - 1] = GetEcuacion(i).MostrarEcuacion();
        }
        return tablero;
    }

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

    public void PintarTablero()
    {
        for (int i = 1; i <= 4; i++)
        {
            GetEcuacion(i).PintarEcuacion();
        }
    }

    public void GenerarTeclado()
    {
        List<string> textoTeclado = new List<string>();
        HashSet<string> opcionesTeclado = new HashSet<string>();
        List<char> posiblesOpciones = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '-', '*', '/' };
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
