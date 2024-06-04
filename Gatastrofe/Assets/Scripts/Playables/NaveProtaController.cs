using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NaveProtaController : MonoBehaviour
{
    public static GameObject mapa;
    public static GameObject btnMapa;

    private void Start()
    {
        Debug.Log("Set");
        mapa = GameObject.Find("Player").transform.GetChild(1).GetChild(0).GetChild(0).gameObject;
        btnMapa = GameObject.Find("Player").transform.GetChild(1).GetChild(0).GetChild(1).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        mapa = GameObject.Find("Player").transform.GetChild(1).GetChild(0).GetChild(0).gameObject;
        btnMapa = GameObject.Find("Player").transform.GetChild(1).GetChild(0).GetChild(1).gameObject;
        Playable.canFly = true;
        ValidarPlanetas();
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        Playable.canFly = false;
    }

    public void IniciarViaje(string codigoDePlaneta)
    {
        Debug.Log("Viaje");
        if (codigoDePlaneta.Equals("PTIE"))
        {
            SceneManagerScript.CargarEscena("Scenes/2.3. PlanetaTierraJugable");
            //GameObject.Find("prota").transform = ;

        }
        else if (codigoDePlaneta.Equals("PMAT"))
        {
            SceneManagerScript.CargarEscena("Scenes/3.1. Planeta8Jugable");
            //GameObject.Find("prota").transform = ;
        }
        else if (codigoDePlaneta.Equals("PFIS"))
        {
            SceneManagerScript.CargarEscena("Scenes/4.1. Planeta7Jugable");
            //GameObject.Find("prota").transform = ;
        }
        else if (codigoDePlaneta.Equals("PEST"))
        {
            SceneManagerScript.CargarEscena("Scenes/5.1. Planeta6Jugable");
            //GameObject.Find("prota").transform = ;
        }
        else if (codigoDePlaneta.Equals("PGEO"))
        {
            SceneManagerScript.CargarEscena("Scenes/6.1. Planeta5Jugable");
            //GameObject.Find("prota").transform = ;
        }
        else if (codigoDePlaneta.Equals("123"))
        {
            Debug.Log("No me mires, yo si funciono");
        }
        else
        {
            Debug.Log("Nais, aqui nos quedamos");
        }
        Playable.canFly = false;
        Playable.canPlay = true;
    }

    public static void ValidarPlanetas()
    {
        Debug.Log("Validar");
        //Si evento nav es 1
        if (!EventManager.ValidarEvento("NAV-23-00"))
        {
            GameObject.Find("Player").transform.GetChild(1).GetChild(0).GetChild(0).GetChild(2).gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            GameObject.Find("Player").transform.GetChild(1).GetChild(0).GetChild(0).GetChild(2).gameObject.GetComponent<Button>().interactable = false;
        }//Si evento nav es 1
        if (!EventManager.ValidarEvento("NAV-31-00"))
        {
            GameObject.Find("Player").transform.GetChild(1).GetChild(0).GetChild(0).GetChild(3).gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            GameObject.Find("Player").transform.GetChild(1).GetChild(0).GetChild(0).GetChild(3).gameObject.GetComponent<Button>().interactable = false;
        }//Si evento nav es 1
        if (!EventManager.ValidarEvento("NAV-41-00"))
        {
            GameObject.Find("Player").transform.GetChild(1).GetChild(0).GetChild(0).GetChild(4).gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            GameObject.Find("Player").transform.GetChild(1).GetChild(0).GetChild(0).GetChild(4).gameObject.GetComponent<Button>().interactable = false;
        }//Si evento nav es 1
        if (!EventManager.ValidarEvento("NAV-51-00"))
        {
            GameObject.Find("Player").transform.GetChild(1).GetChild(0).GetChild(0).GetChild(5).gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            GameObject.Find("Player").transform.GetChild(1).GetChild(0).GetChild(0).GetChild(5).gameObject.GetComponent<Button>().interactable = false;
        }//Si evento nav es 1
        if (!EventManager.ValidarEvento("NAV-61-00"))
        {
            GameObject.Find("Player").transform.GetChild(1).GetChild(0).GetChild(0).GetChild(6).gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            GameObject.Find("Player").transform.GetChild(1).GetChild(0).GetChild(0).GetChild(6).gameObject.GetComponent<Button>().interactable = false;
        }
    }

    public void CloseMap()
    {
        Debug.Log("Close");
        mapa.SetActive(false);
        btnMapa.SetActive(false);
        Playable.canPlay = true;
        GameObject.Find("Player").transform.GetChild(1).GetChild(0).GetChild(3).gameObject.SetActive(true);
    }

    public static void OpenMap() 
    {
        Debug.Log("Open");
        GameObject.Find("Player").transform.GetChild(1).GetChild(0).GetChild(3).gameObject.SetActive(false);
        mapa.SetActive(true);
        btnMapa.SetActive(true);
        Playable.canPlay = false;
    }

}