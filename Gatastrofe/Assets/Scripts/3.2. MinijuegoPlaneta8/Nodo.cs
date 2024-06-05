using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodo  
{
    private Ecuacion dato;
    private Nodo siguiente;
    private Nodo anterior;

    public Nodo(Ecuacion dato)
    {
        this.dato = dato;
        this.siguiente = null;
        this.anterior = null;
    }

    public Ecuacion GetDato()
    {
        return dato;
    }

    public void SetDato(Ecuacion dato)
    {
        this.dato = dato;
    }

    public Nodo GetSiguiente()
    {
        return siguiente;
    }

    public void SetSiguiente(Nodo siguiente)
    {
        this.siguiente = siguiente;
    }

    public Nodo GetAnterior()
    {
        return anterior;
    }

    public void SetAnterior(Nodo anterior)
    {
        this.anterior = anterior;
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
