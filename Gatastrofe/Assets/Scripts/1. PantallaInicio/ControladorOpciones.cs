using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorOpciones : MonoBehaviour
{
    public static int Volumen;

    public void CambiarVolumen(int volumen)
    {
        PlayerPrefs.SetInt("vol", volumen);
    }
}
