using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playable : MonoBehaviour
{
    //GameObjects
    public GameObject prota;
    public GameObject camara;
    public Animator animator;
    BoxCollider boxCollider;
    GameObject pickedObject = null;

    //Atributos de estado
    public static float velocidad = 5;
    public bool canPick = false;
    public bool canDialog = false;
    public static bool canPlay = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        boxCollider = prota.GetComponent<BoxCollider>();
        Physics.IgnoreCollision(gameObject.GetComponent<BoxCollider>(), boxCollider);
    }

    // Update is called once per frame
    void Update()
    {
        if (canPlay)
        {
            Move();
            Interact();
        }
    }

    public void Move()
    {
        //Mover W + D
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isWalking", true);
            prota.transform.rotation = Quaternion.Euler(0, 45, 0);
            gameObject.transform.Translate(new Vector3(velocidad * Time.deltaTime / Mathf.Sqrt(2), 0, velocidad * Time.deltaTime / Mathf.Sqrt(2)));

        }
        //Mover W + A
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isWalking", true);
            prota.transform.rotation = Quaternion.Euler(0, -45, 0);
            gameObject.transform.Translate(new Vector3(-velocidad * Time.deltaTime / Mathf.Sqrt(2), 0, velocidad * Time.deltaTime / Mathf.Sqrt(2)));

        }
        //Mover S + D
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isWalking", true);
            prota.transform.rotation = Quaternion.Euler(0, 135, 0);
            gameObject.transform.Translate(new Vector3(velocidad * Time.deltaTime / Mathf.Sqrt(2), 0, -velocidad * Time.deltaTime / Mathf.Sqrt(2)));

        }
        //Mover S + A
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isWalking", true);
            prota.transform.rotation = Quaternion.Euler(0, -135, 0);
            gameObject.transform.Translate(new Vector3(-velocidad * Time.deltaTime / Mathf.Sqrt(2), 0, -velocidad * Time.deltaTime / Mathf.Sqrt(2)));

        }
        //Mover Solo W
        else if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isWalking", true);
            prota.transform.rotation = Quaternion.Euler(0, 0, 0);
            gameObject.transform.Translate(new Vector3(0, 0, velocidad * Time.deltaTime));
        }
        //Mover Solo S
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isWalking", true);
            prota.transform.rotation = Quaternion.Euler(0, 180, 0);
            gameObject.transform.Translate(new Vector3(0, 0, -velocidad * Time.deltaTime));
        }
        //Mover Solo D
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isWalking", true);
            prota.transform.rotation = Quaternion.Euler(0, 90, 0);
            gameObject.transform.Translate(new Vector3(velocidad * Time.deltaTime, 0, 0));
        }
        //Mover Solo A
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isWalking", true);
            prota.transform.rotation = Quaternion.Euler(0, -90, 0);
            gameObject.transform.Translate(new Vector3(-velocidad * Time.deltaTime, 0, 0));
        }
        else if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") > 0)
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            animator.SetBool("isWalking", true);
            prota.transform.rotation = Quaternion.LookRotation(movement);
            transform.Translate(movement * velocidad * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        prota.transform.localPosition = new Vector3(0, 1, 0);
        animator.SetBool("isPicking", false);
    }

    public void Interact()
    {
        if (Input.GetKey(KeyCode.E) && canPick /*&& EventManager.ValidarEvento("INI-22-00")*/)
        {
            animator.SetBool("isPicking", true);
            Destroy(pickedObject);
            pickedObject = null;
        }
        else if (Input.GetKey(KeyCode.E) && canDialog)
        {
            //Habla care tabla
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pick"))
        {
            pickedObject = other.gameObject;
            canDialog = false;
            canPick = true;
        }
        else if (other.CompareTag("Dialog"))
        {
            canPick = false;
            canDialog = true;
        }
        else if (other.CompareTag("PuertaBasurero"))
        {
            if (GameObject.FindGameObjectsWithTag("Pick").Length == 0)
            {
                EventManager.ModificarEstadoEvento("INI-22-00", 1);
                SceneManagerScript.CargarEscena("Scenes/2.1. PlanetaTierraTutorial");
                canPlay = false;
            }
            else
            {
                //Mostrar aviso en el HUD de que todavía faltan partes de la nave
                Debug.Log("Faltan partes de la nave.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (canPick)
        {
            canPick = false;
            animator.SetBool("isWalking", true);
        }
        else if (canDialog)
        {
            canDialog = false;
        }
    }
}
