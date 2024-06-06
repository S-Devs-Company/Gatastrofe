using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiezaController : MonoBehaviour
{
    private bool isPlayable = false;
    private float velocidad;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        velocidad = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayable)
        {
            if (transform.position.x < 30)
            {
                transform.Translate(Time.deltaTime * velocidad * Vector3.right);
            }
            else {
                Destroy(gameObject);
            }
        }

    }

    private void OnMouseDown()
    {
        isPlayable = true;
        rb.isKinematic = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Limites")) {
            Destroy(gameObject);
        }
    }
}
