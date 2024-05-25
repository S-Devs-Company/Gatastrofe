using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    static int CurrentScene = 0;
    public Animator CinematicaContexto;
    float contador = 0;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentScene == 0)
        {
            float AnimDuration = CinematicaContexto.GetCurrentAnimatorStateInfo(0).length;
            contador += Time.deltaTime;
            if (CurrentScene == 0 && contador >= AnimDuration)
            {
                nextScene();
            }
        }

        if (Input.GetKeyDown("space"))
        {
            nextScene();
        }
    }

    public void nextScene()
    {
        CurrentScene += 1;
        SceneManager.LoadScene(CurrentScene);
    }
}