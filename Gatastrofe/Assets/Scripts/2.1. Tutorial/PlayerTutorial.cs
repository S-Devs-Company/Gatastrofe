using System;
using UnityEngine;

public class PlayerTutorial : MonoBehaviour
{
    Animator animator;

    public static Boolean primerDialogo = false;
    public static Boolean segundoDialogo = false;
    public static Boolean imDone = false; //Si ya cumplió el evento del basurero

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        if (!EventManager.ValidarEvento("INI-22-00"))
        {
            transform.position = new Vector3(9f, 0f, -0.5f);
            imDone = true;
            primerDialogo = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (EventManager.ValidarEvento("INI-22-00"))
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
                    gameObject.transform.Translate(new Vector3(0.399f, 0, 0.917f) * Playable.velocidad * Time.deltaTime);
                }
                else
                {
                    animator.SetBool("isWalking", false);
                    /*
                     * 
                     * 
                     * Se ejecuta el primer dialogo
                     * 
                     * 
                     * 
                     */
                }
            }
            //Si ya el prota hizo su dialogo con el cientifico
            else if (primerDialogo && EventManager.ValidarEvento("INI-22-00") && !segundoDialogo)
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
                    SceneManagerScript.CargarEscena("Scenes/2.2. BasureroJugable");
                    Playable.canPlay = true;
                }

            }
        }
        else
        {
            //Si ya terminó el primer dialogo y lo de la basura
            if (!EventManager.ValidarEvento("INI-22-00") && primerDialogo && !segundoDialogo)
            {
                GameObject.Find("cientifico").GetComponent<StoryDialogController>().DialogCode = "PEAR-23-";
                GameObject.Find("cientifico").GetComponent<StoryDialogController>().CantDialog = 3;
                //Camina hacia el cientifico
                GameObject.Find("prota").transform.rotation = Quaternion.Euler(0f, -77.9f, 0f);
                if (gameObject.transform.position.z < 1)
                {
                    animator.SetBool("isWalking", true);
                    gameObject.transform.Translate(new Vector3(-0.977f, 0, 0.21f) * Playable.velocidad * Time.deltaTime);
                }
                else
                {
                    animator.SetBool("isWalking", false);

                    /*
                     * 
                     * 
                     * Se ejecuta el segundo dialogo
                     * 
                     * 
                     */
                }
            }
            else if (segundoDialogo && !EventManager.ValidarEvento("INI-22-00") && primerDialogo)
            {
                EventManager.ModificarEstadoEvento("INI-21-00", 1);
                //Desvanecido de la camara
                SceneManagerScript.CargarEscena("Scenes/2.3. PlanetaTierraJugable");
                Playable.canPlay = true;
            }
        }
    }
}
