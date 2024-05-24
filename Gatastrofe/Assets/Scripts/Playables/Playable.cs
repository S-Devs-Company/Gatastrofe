using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Playable : MonoBehaviour
{
    //GameObjects
    public GameObject prota;
    public GameObject camara;
    public Animator animator;
    private Rigidbody rigidBody;

    //Atributos de estado
    public static float velocidad = 5;
    public static Boolean isStuck = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rigidBody = GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        //Mover W + D
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) && !isStuck)
        {
            animator.SetBool("isWalking", true);
            prota.transform.rotation = Quaternion.Euler(0, 45, 0);
            gameObject.transform.Translate(new Vector3(velocidad * Time.deltaTime, 0, velocidad * Time.deltaTime));

        }
        //Mover W + A
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && !isStuck)
        {
            animator.SetBool("isWalking", true);
            prota.transform.rotation = Quaternion.Euler(0, -45, 0);
            gameObject.transform.Translate(new Vector3(-velocidad * Time.deltaTime, 0, velocidad * Time.deltaTime));

        }
        //Mover S + D
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && !isStuck)
        {
            animator.SetBool("isWalking", true);
            prota.transform.rotation = Quaternion.Euler(0, 135, 0);
            gameObject.transform.Translate(new Vector3(velocidad * Time.deltaTime, 0, -velocidad * Time.deltaTime));

        }
        //Mover S + A
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && !isStuck)
        {
            animator.SetBool("isWalking", true);
            prota.transform.rotation = Quaternion.Euler(0, -135, 0);
            gameObject.transform.Translate(new Vector3(-velocidad * Time.deltaTime, 0, -velocidad * Time.deltaTime));

        }
        //Mover Solo W
        else if (Input.GetKey(KeyCode.W) && !isStuck)
        {
            animator.SetBool("isWalking", true);
            prota.transform.rotation = Quaternion.Euler(0, 0, 0);
            gameObject.transform.Translate(new Vector3(0, 0, velocidad * Time.deltaTime));
        }
        //Mover Solo S
        else if (Input.GetKey(KeyCode.S) && !isStuck)
        {
            animator.SetBool("isWalking", true);
            prota.transform.rotation = Quaternion.Euler(0, 180, 0);
            gameObject.transform.Translate(new Vector3(0, 0, -velocidad * Time.deltaTime));
        }
        //Mover Solo D
        else if (Input.GetKey(KeyCode.D) && !isStuck)
        {
            animator.SetBool("isWalking", true);
            prota.transform.rotation = Quaternion.Euler(0, 90, 0);
            gameObject.transform.Translate(new Vector3(velocidad * Time.deltaTime, 0, 0));
        }
        //Mover Solo A
        else if (Input.GetKey(KeyCode.A) && !isStuck)
        {
            animator.SetBool("isWalking", true);
            prota.transform.rotation = Quaternion.Euler(0, -90, 0);
            gameObject.transform.Translate(new Vector3(-velocidad * Time.deltaTime, 0, 0));
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKey(KeyCode.E) && other.CompareTag("Pick"))
        {
            animator.SetBool("isPicking", true);
            animator.SetBool("isPicking", false);
        }
        else if (Input.GetKey(KeyCode.E) && other.CompareTag("Dialog"))
        {
            //Accion de dialogo
        }
    }


}
