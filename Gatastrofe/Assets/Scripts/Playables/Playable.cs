using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playable : MonoBehaviour
{
    //GameObjects
    public GameObject prota;
    public GameObject camara;
    public Animator animator;
    BoxCollider boxCollider;

    //Atributos de estado
    public static float velocidad = 5;
    public Boolean canPick = false;
    private Boolean canDialog = false;
    public static Boolean canPlay = true;

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
        else
        {
            animator.SetBool("isWalking", false);
        }
        prota.transform.localPosition = new Vector3(0, 1, 0);

    }

    public void Interact()
    {
        if (Input.GetKey(KeyCode.E) && canPick)
        {
            animator.SetBool("isPicking", true);
            //agarramelo

        }
        else if (Input.GetKey(KeyCode.E) && canDialog)
        {
            //Habla care tabla
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.CompareTag("Pick"))
        {
            Debug.Log("Colisiona");
            canPick = true;
        }
        else if (collision.collider.CompareTag("Dialog"))
        {
            canPick = false;
            canDialog = true;
        }

    }

    /*

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Colisionant");
        if (canPick)
        {
            canPick = false;
        }
        else if (canDialog)
        {
            canDialog = false;
        }
    }
    */
}
