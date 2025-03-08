using System;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private bool _dragging = false;
    private Vector2 _offsetVector;
    private Camera _camera;

// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _camera = Camera.main;
        _offsetVector = Vector3.zero;
    }

// Update is called once per frame
    void Update()
    {
        if (_dragging && _camera)
        {
            Vector2 newPos = _camera.ScreenToWorldPoint(Input.mousePosition);
            newPos += _offsetVector;
        
            // set new position
            transform.position = newPos;
        }
    }

    private void OnMouseDown()
    {
        _dragging = true;
        if (Camera.main != null) _offsetVector = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        _dragging = false;
    }
}
