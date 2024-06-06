using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroideController : MonoBehaviour
{
    private const float velocidad = 5;

    private void Start()
    {
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), GameObject.Find("Limites").GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -10)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.left * velocidad * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
