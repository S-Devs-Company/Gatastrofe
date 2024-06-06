using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ControladorMinijuegoEstadistica : MonoBehaviour
{
    [SerializeField] GameObject Sombrero1;
    [SerializeField] GameObject Sombrero2;
    [SerializeField] GameObject Sombrero3;
    [SerializeField] GameObject Sombrero4;
    [SerializeField] GameObject Sombrero5;
    [SerializeField] GameObject Cuerpo;

    List<Personaje> Personajes = new List<Personaje>();
    List<GameObject> Sombreros = new List<GameObject>();

    Personaje personaje;

    private void Start()
    {
        
    }


    public void GenerarPersonajes()
    {
        for (int i = 0; i > 12; i++)
        {
            GameObject SombreroGenerado = Sombreros[Random.Range(0,5)];
            Personajes.Add(new Personaje(Cuerpo, SombreroGenerado));
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EventManager.ModificarEstadoEvento("PEJ-52-00", 1);
            SceneManagerScript.CargarEscena("Scenes/5.1. Planeta6Jugable");
        }
    }
}
