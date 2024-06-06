using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitarInstruciones : MonoBehaviour
{
    public static bool startMiniGame;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (SceneManager.GetActiveScene().name == "3.2. MinijuegoPlaneta8")
            {
                gameObject.SetActive(false);
            }
            else
            {
                SceneManagerScript.CargarMinijuego();
            }
        }
    }
}
