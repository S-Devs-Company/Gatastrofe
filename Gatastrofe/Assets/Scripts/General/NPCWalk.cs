using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWalk : MonoBehaviour
{
    [SerializeField] private float vel = 5f;
    private bool canWalk = true;
    private int walkSide = 1; //-1 izq // 1 der
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canWalk)
        {
            if (walkSide == 1) 
            {
                transform.rotation = Quaternion.Euler(0f, 90f, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0f, -90f, 0);
            }
            transform.Translate(new Vector3(vel * Time.deltaTime * walkSide, 0, 0), Space.World);
        }
        if (transform.position.x >= 45f)
        {
            walkSide = -1;
        }
        else if (transform.position.x <= -4f)
        {
            walkSide = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        canWalk = false;
        animator.SetBool("isWalking", false);
    }

    private void OnTriggerExit(Collider other)
    {
        canWalk = true;
        animator.SetBool("isWalking", true);
    }
}
