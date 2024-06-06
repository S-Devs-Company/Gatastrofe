using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiezaSpawnerController : MonoBehaviour
{
    [SerializeField] List<GameObject> piezasPrefabs = new List<GameObject>();
    private float timer;
    private float tiempoDeSpawn;


    // Start is called before the first frame update
    void Start()
    {
        tiempoDeSpawn = 5;
        timer = 5;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > tiempoDeSpawn)
        {
            int numPieza = Random.Range(0, 4);
            Vector3 posicion = new Vector3(-30f, 70f, 0f);
            Instantiate(piezasPrefabs[numPieza], posicion, piezasPrefabs[numPieza].transform.rotation);
            timer = 0;
        }

    }
}
