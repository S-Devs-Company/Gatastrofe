using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropManager : MonoBehaviour
{
    [SerializeField] bool hasPhysics = true;
    [SerializeField] float forceMultiplier = 1f;
    [SerializeField] float minDragDistance = 0.1f;
    [SerializeField] Camera cam;

    Vector3 mousePos;
    Vector3 startPos;
    Rigidbody rb;
    Vector3 initialVelocity;

    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }

        if (hasPhysics)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    Vector3 GetMousePos()
    {
        return cam.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePos = Input.mousePosition - GetMousePos();
        startPos = transform.position;
        if (hasPhysics)
        {
            initialVelocity = rb.velocity;
            rb.velocity = Vector3.zero;
        }
    }

    private void OnMouseDrag()
    {
        transform.position = cam.ScreenToWorldPoint(Input.mousePosition - mousePos);
    }

    private void OnMouseUp()
    {
        if (hasPhysics) return;

        Vector3 dragDirection = transform.position - startPos;
        float dragDistance = dragDirection.magnitude;
        if (dragDistance >= minDragDistance && rb.velocity.magnitude <= 1f)
        {
            dragDirection.Normalize();
            rb.AddForce(dragDirection * dragDistance * forceMultiplier, ForceMode.Impulse);
        }
        rb.velocity = initialVelocity;
    }
}