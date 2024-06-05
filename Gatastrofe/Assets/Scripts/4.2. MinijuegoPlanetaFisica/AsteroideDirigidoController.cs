using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroideDirigidoController : MonoBehaviour
{
    [SerializeField] public GameObject target;
    [SerializeField] float velocidad;
    private Vector3 direccion;

    // Start is called before the first frame update
    void Start()
    {
        CalcularDireccionTarget();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Time.deltaTime * velocidad * direccion.normalized);
    }

    public void CalcularDireccionTarget()
    {
        direccion = new Vector3(0f, 0f, target.transform.position.z) - gameObject.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Estructura"))
        {
            MinijuegoPlaneta7Controller.Choque();
        }
    }
}
