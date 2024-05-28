using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public static int CurrentScene = 0;
    public Animator CinematicaContexto;
    float contador = 0;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (CurrentScene == SceneManager.GetSceneByName("Scenes/0. CinematicaDeContexto").buildIndex)
        {
            float AnimDuration = CinematicaContexto.GetCurrentAnimatorStateInfo(0).length;
            contador += Time.deltaTime;
            if (contador >= AnimDuration || Input.GetKeyDown(KeyCode.Q))
            {
                CargarEscena("Scenes/1. PantallaDeInicio");
            }
        }
        else if (CurrentScene == SceneManager.GetSceneByName("Scenes/2.1. PlanetaTierraTutorial").buildIndex)
        {
            if (!EventManager.ValidarEvento("INI-21-00"))
            {
                CargarEscena("Scenes/2.3. PlanetaTierraJugable");
            }
        }
        else if (CurrentScene == SceneManager.GetSceneByName("Scenes/2.2. BasureroJugable").buildIndex)
        {

        }
        else if (CurrentScene == SceneManager.GetSceneByName("Scenes/2.3. PlanetaTierraJugable").buildIndex)
        {

        }
    }

    public static void CargarEscena(String escena)
    {
        SceneManager.LoadScene(escena);
        CurrentScene = SceneManager.GetSceneByName(escena).buildIndex;
    }

    public static void CargarEscena(int escena)
    {
        SceneManager.LoadScene(escena);
        CurrentScene = escena;
    }
}