using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropManager : MonoBehaviour
{
    [SerializeField] Camera cam;

    Vector3 mousePos;
    Vector3 startPos;

    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    private void Update()
    {
        transform.position = new Vector3(0f, transform.position.y, transform.position.z);
    }

    Vector3 GetMousePos()
    {
        return cam.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePos = Input.mousePosition - GetMousePos();
        startPos = transform.position;
    }

    private void OnMouseDrag()
    {
        transform.position = cam.ScreenToWorldPoint(Input.mousePosition - mousePos);
    }
}