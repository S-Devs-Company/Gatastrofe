using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    int CurrentScene = 0;

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
        if(Input.GetKeyDown("space")){
            nextScene();
        }
    }

    public void nextScene (){
        CurrentScene += 1;
        SceneManager.LoadScene(CurrentScene);
    }
}