using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorBalanza : MonoBehaviour
{
    [SerializeField] private GameObject plato;
    [SerializeField] private GameObject NPCS;
    [SerializeField] private float posZ;

    private void Update()
    {
        plato.transform.position = new Vector3(0f, transform.position.y - 18f, posZ);
        NPCS.transform.position = new Vector3(0f, transform.position.y - 13.5f, posZ);
    }

}
