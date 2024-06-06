using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    private GameObject cuerpo;
    private GameObject sombrero;

    public Personaje(GameObject cuerpo, GameObject sombrero)
    {
        this.cuerpo = cuerpo;
        this.sombrero = sombrero;
    }

    public GameObject GetSombrero()
    {
        return sombrero;
    }

    public GameObject GetCuerpo()
    {
        return cuerpo;
    }

    public void SetCuepo(GameObject cuerpo)
    {
        this.cuerpo = cuerpo;
    }

    public void SerSombrero(GameObject sombrero)
    {
        this.sombrero = sombrero;
    }
}
