using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablero : MonoBehaviour
{
    public ListaDobleEnlazada ecuaciones;
    public Ecuacion ecuacionObject;



    public Tablero()
    {
        ecuaciones = new ListaDobleEnlazada();
    }

    public void GenerarTablero()
    {
        for (int i = 1; i <= 4; i++)
        {
            Vector3 pos = new Vector3(0,(i-1)*(-125) + 80,1000);
            Quaternion rot = new Quaternion();
            ecuaciones.AgregarElemento(Instantiate(ecuacionObject,pos,rot,gameObject.transform));

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

    // Start is called before the first frame update
    void Start()
    {
        GenerarTablero();
        //ecuacionObject.GenerarEcuacion();
        //ecuacionObject.MostrarEcuacion();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
