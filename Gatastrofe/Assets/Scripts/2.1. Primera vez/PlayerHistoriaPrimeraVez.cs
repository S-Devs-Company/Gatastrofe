using System;
using UnityEngine;

public class PlayerHistoriaPrimeraVez : MonoBehaviour
{
    Animator animator;

    Boolean primerDialogo = false;
    Boolean segundoDialogo = false;
    public static Boolean imDone = false; //Si ya cumplió el evento del basurero

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Si el porta no ha hecho su dialogo con el cientifico y el mejor amigo no ha terminado
        if (!primerDialogo && !MejorAmigoPrimeraVez.imDone)
        {
            animator.SetBool("isWalking", false);
        }
        //Si el portagonista no ha hecho su dialogo con el cientifico y ya el mejor amigo terminó
        else if (!primerDialogo && MejorAmigoPrimeraVez.imDone)
        {
            //Se rota hacia el cientifico y camina
            GameObject.Find("prota").transform.rotation = Quaternion.Euler(0f, 26.1f, 0f);
            if (gameObject.transform.position.z < 0f)
            {
                animator.SetBool("isWalking", true);
                gameObject.transform.Translate(new Vector3(0.399f,0,0.917f) * Playable.velocidad * Time.deltaTime);
            }
            else
            {
                animator.SetBool("isWalking", false);
            }
        }
        //Si ya el prota hizo su dialogo con el cientifico
        else if (primerDialogo)
        {
            //Se rota hacia el basurero y camina
            GameObject.Find("prota").transform.rotation = Quaternion.Euler(0f, 96.82f, 0f);
            if (gameObject.transform.position.z > -0.5f)
            {
                animator.SetBool("isWalking", true);
                gameObject.transform.Translate(new Vector3(0.99f, 0, -0.049f) * Playable.velocidad * Time.deltaTime);
            }
            else
            {
                animator.SetBool("isWalking", false);
            }

        }
        else if (imDone)
        {
            //Camina hacia el cientifico
            //tiene su ultimo dialogo con el cientifico
            //se cambia a las escena de planeta tierra libre
        }
        else if (segundoDialogo)
        {
            //Cambio del estado del evento de historia primera vez
            //Cambio a la escena del modo libre
        }

        //Inputs que simulan los dialogos
        if (Input.GetKeyDown(KeyCode.R))
        {
            primerDialogo = true;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            imDone = true;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            segundoDialogo = true;
        }


        /*
        if (EventManager.ValidarEvento("INI-22-00"))
        {
            //Aqui va la secuencia del prota en la historia
        }
        */
    }
}
