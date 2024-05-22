using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SceneManagerScript : MonoBehaviour
{
    int CurrentScene = 0;
    public Animator CinematicaContexto;
    double contador = 0;

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
        contador += Time.deltaTime;
        if (CurrentScene == 0 && contador >= 10)
        {
            nextScene();
        }
        if(Input.GetKeyDown("space")){
            nextScene();
        }
    }

    public void nextScene (){
        CurrentScene += 1;
        SceneManager.LoadScene(CurrentScene);
    }
}