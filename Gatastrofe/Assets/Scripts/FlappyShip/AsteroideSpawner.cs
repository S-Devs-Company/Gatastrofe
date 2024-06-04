using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroideSpawner : MonoBehaviour
{
    [SerializeField] private GameObject asteroidePrefab;
    [SerializeField] private GameObject nave;
    float contador;

    // Update is called once per frame
    void Update()
    {
        contador += Time.deltaTime;
        if (contador >= Random.Range(2f,4f))
        {
            Vector3 posicion = new Vector3(10, nave.transform.position.y, 0);
            Quaternion rotacion = new Quaternion();
            Instantiate(asteroidePrefab, posicion, rotacion);
            contador = 0;
        }
    }
}
