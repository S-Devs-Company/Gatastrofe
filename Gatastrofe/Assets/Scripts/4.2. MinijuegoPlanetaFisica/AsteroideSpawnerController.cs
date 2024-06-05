using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AsteroideSpawnerController : MonoBehaviour
{
    [SerializeField] GameObject prefabAsteroide;
    [SerializeField] List<GameObject> posiblesTargets = new List<GameObject>();
    [SerializeField] List<GameObject> targetsAdvertencias = new List<GameObject>();
    [SerializeField] float tiempoRespawn;
    private int opcion;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        opcion = 0;
        timer = 0;
        targetsAdvertencias[opcion].gameObject.SetActive(true);
        GameObject newTarget = posiblesTargets[opcion];
        prefabAsteroide.transform.position = new Vector3(-350f, 20f, 0f);
        prefabAsteroide.GetComponent<AsteroideDirigidoController>().target = newTarget;
        prefabAsteroide.GetComponent<AsteroideDirigidoController>().CalcularDireccionTarget();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (7 > timer)
        {
            targetsAdvertencias[opcion].GetComponentInChildren<TextMeshProUGUI>().text = "Choque en " + Convert.ToInt64(7 - timer) + " s..";
        }
        else
        {
            targetsAdvertencias[opcion].gameObject.SetActive(false);
        }
        if (timer > tiempoRespawn)
        {
            opcion = UnityEngine.Random.Range(0, 2);
            targetsAdvertencias[opcion].gameObject.SetActive(true);
            GameObject newTarget = posiblesTargets[opcion];
            prefabAsteroide.transform.position = new Vector3(-350f, 20f, 0f);
            prefabAsteroide.GetComponent<AsteroideDirigidoController>().target = newTarget;
            prefabAsteroide.GetComponent<AsteroideDirigidoController>().CalcularDireccionTarget();
            timer = 0;
        }
    }
}
