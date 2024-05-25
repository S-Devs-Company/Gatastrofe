using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaDobleEnlazada
{
    private Nodo ptr;
    private Nodo fin;
    private int size;

    public ListaDobleEnlazada()
    {
        this.ptr = null;
        this.fin = null;
        this.size = 0;
    }

    private Nodo CrearNodo(Ecuacion ecuacion)
    {
        return new Nodo(ecuacion);
    }

    public bool AgregarElemento(Ecuacion ecuacion)
    {
        Nodo nuevoNodo = CrearNodo(ecuacion);
        try
        {
            if (ptr == null)
            {
                ptr = nuevoNodo;
                fin = nuevoNodo;
                size++;
                return true;
            }
            else
            {
                fin.SetSiguiente(nuevoNodo);
                nuevoNodo.SetAnterior(fin);
                fin = nuevoNodo;
                size++;
                return true;
            }
        }
        catch (Exception)
        {
            return false;
        }
    }

    public Nodo GetElemento(int posicion)
    {
        int i = 1;
        if (posicion > size)
        {
            return null;
        }
        else
        {
            Nodo x = ptr;
            while (i < posicion)
            {
                x = x.GetSiguiente();
                i++;
            }
            return x;
        }
    }

    public int GetSize()
    {
        return size;
    }

    public Nodo GetPtr()
    {
        return ptr;
    }

    public Nodo GetFinal()
    {
        return fin;
    }

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
