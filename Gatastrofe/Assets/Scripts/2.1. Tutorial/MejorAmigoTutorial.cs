using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MejorAmigoPrimeraVez : MonoBehaviour
{
    Animator animator;
    Boolean dialogDone = false;
    public static Boolean imDone = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Playable.canPlay = false;
    }

    // Update is called once per frame
    void Update()
    {

        //Inicia el dialogo
        //Fin del dialogo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dialogDone = true;
        }

        //Si no se ha completado la primera parte de la historia
        if (EventManager.ValidarEvento("INI-22-00"))
        {
            if (!dialogDone)
            {
                if (gameObject.transform.position.z > -7.5f)
                {
                    animator.SetBool("isWalking", true);
                    gameObject.transform.Translate(Vector3.forward * Playable.velocidad * Time.deltaTime);
                }
                else
                {
                    animator.SetBool("isWalking", false);
                }
            }
            else
            {
                transform.rotation = Quaternion.Euler(0f, 293.1f, 0f);
                if (gameObject.transform.position.z < -4.5f)
                {
                    animator.SetBool("isWalking", true);
                    gameObject.transform.Translate(Vector3.forward * Playable.velocidad * Time.deltaTime);
                }
                else
                {
                    animator.SetBool("isWalking", false);
                    transform.rotation = Quaternion.Euler(0f, 293.1f + 180f, 0f);
                    imDone = true;
                }
            }
        }
        else
        {
            transform.position = new Vector3(-12f, 0.3f, -5f);
            transform.rotation = Quaternion.Euler(0f, 113.1f, 0f);
            imDone = true;
            dialogDone = true;
        }
    }
}
