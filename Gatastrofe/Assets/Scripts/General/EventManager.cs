using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private const string ruta = "Assets\\Files\\EventManager.txt";
    private static Dictionary<string, int> EventDictionary = new Dictionary<string, int>();

    private void Awake()
    {
        DontDestroyOnLoad(this);
        LeerArchivo();
    }

    void Start()
    {

    }

    //Lee el archivo y lo pega en el diccionario
    public static void LeerArchivo()
    {
        using (StreamReader reader = new StreamReader(ruta))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(",");
                EventDictionary.Add(parts[0], int.Parse(parts[1]));
            }

        }
    }

    //toma el diccionario y lo escribe en el archivo
    public static void EscribirArchivo()
    {
        using (StreamWriter writer = new StreamWriter(ruta))
        {
            foreach (var entry in EventDictionary)
            {
                writer.WriteLine(entry.Key + "," + entry.Value);
            }
        }
    }

    //Modifica el evento en el diccionario y lo escribe en el archivo
    public static void ModificarEstadoEvento(string codigo, int nuevoEstado)
    {
        EventDictionary[codigo] = nuevoEstado;
        EscribirArchivo();
    }

    public static Boolean ValidarEvento(String codigoEvt)
    {
        return (EventDictionary[codigoEvt] == 0);
    }

    public void ReiniciarEventos()
    {
        using (StreamWriter writer = new StreamWriter(ruta))
        {
            foreach (var entry in EventDictionary)
            {
                writer.WriteLine(entry.Key + "," + 0);
            }
        }
    }
}
