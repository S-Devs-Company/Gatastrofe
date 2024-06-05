using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControladorInversoBarra : MonoBehaviour
{
    [SerializeField] GameObject PlatoD;
    [SerializeField] GameObject PlatoI;

    private void Update()
    {
        float angle = Vector3.Angle(new Vector3(0, 0.3f, 0), PlatoD.transform.position);
        transform.rotation = Quaternion.Euler(angle, 0, 0);
    }
}
