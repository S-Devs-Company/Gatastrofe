using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveController : MonoBehaviour
{
    [SerializeField] private float fuerzaDeSalto = 200;
    private Rigidbody rigidBodyNave;
    // Start is called before the first frame update
    void Start()
    {
        rigidBodyNave = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump(); 
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rigidBodyNave.AddForce(Vector3.up*fuerzaDeSalto);
        }
    }
}
