using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SeleccionadorRespuesta : MonoBehaviour
{
    public static TextMeshProUGUI incognita;
    public void Seleccionar()
    {
        if (incognita != null)
        {
            incognita.GetComponentInParent<Image>().color = Color.white;

        }
        SeleccionadorRespuesta.incognita = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        incognita.GetComponentInParent<Image>().color = Color.cyan;
    }

    public void Responder()
    {
        if (SeleccionadorRespuesta.incognita != null)
        {
            incognita.GetComponentInParent<Image>().color = Color.white;
            incognita.SetText(gameObject.GetComponentInChildren<TextMeshProUGUI>().text);
        }
    }

}
