using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPantallaInicio : MonoBehaviour
{
    [SerializeField] GameObject PanelConfirmacion;
    [SerializeField] GameObject Creditos;
    [SerializeField] GameObject Opciones;
    [SerializeField] GameObject BotonCreditos;

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
        BotonCreditos.SetActive(false);
    }

    public void CloseCreditos()
    {
        Creditos.SetActive(false);
        BotonCreditos.SetActive(true);
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
