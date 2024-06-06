using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEliminadorController : MonoBehaviour
{
    private bool isFull;
    // Start is called before the first frame update
    void Start()
    {
        isFull = false;
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerStay(Collider other)
    {
        if (isFull && other.CompareTag("Piezas"))
        {
            Destroy(other.gameObject);
        }
    }

    public void setFull(bool full)
    {
        isFull = full;
    }
}
