using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerController : MonoBehaviour
{
    public static bool intentoMinijuego = false;
    // Start is called before the first frame update
    void Start()
    {
        if (intentoMinijuego)
        {
            gameObject.transform.position = new Vector3(0,0,20);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
