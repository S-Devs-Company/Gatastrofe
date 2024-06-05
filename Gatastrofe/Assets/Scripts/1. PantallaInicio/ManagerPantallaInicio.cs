using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPantallaInicio : MonoBehaviour
{
    [SerializeField] GameObject PanelConfirmacion;
    [SerializeField] GameObject Creditos;
    [SerializeField] GameObject Opciones;

    public void OpenPanelConfirmacion()
    {
        PanelConfirmacion.SetActive(true);
    }

    public void ClosePanelConfirmacion()
    {
        PanelConfirmacion.SetActive(false);
    }

    public void OpenCreditos()
    {
        Creditos.SetActive(true);
        GameObject.Find("BtnCreditos").SetActive(false);
    }

    public void CloseCreditos()
    {
        Creditos.SetActive(false);
        GameObject.Find("BtnCreditos").SetActive(true);
    }

    public void OpenOpciones()
    {
        Opciones.SetActive(true);
    }

    public void CloseOpciones()
    {
        Opciones.SetActive(false);
    }
}
