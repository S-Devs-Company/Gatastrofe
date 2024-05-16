using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablero : MonoBehaviour
{
    public Ecuacion ecuacion1;
    public Ecuacion ecuacion2;
    public Ecuacion ecuacion3;
    public Ecuacion ecuacion4;

    public ListaDobleEnlazada ecuaciones;



    public Tablero()
    {
        ecuaciones = new ListaDobleEnlazada();
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerarTablero();
        
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

    public bool ResolverTablero(string incognita1, string incognita2, string incognita3, string incognita4)
    {
        if (GetEcuacion(1).Resolver(incognita1))
        {
            if (GetEcuacion(2).Resolver(incognita2))
            {
                if (GetEcuacion(3).Resolver(incognita3))
                {
                    if (GetEcuacion(4).Resolver(incognita4))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
