using System;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private bool _dragging = false;
    private Vector3 _offsetVector;
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
        if (_dragging && _camera && !GameManager.Instance.isLaunching)
        {
            Vector3 newPos = _camera.ScreenToWorldPoint(Input.mousePosition);
            newPos += _offsetVector;
            newPos.z = 0;
        
            // set new position
            transform.position = newPos;
        }
    }

    private void OnMouseDown()
    {
        _dragging = true;
        _offsetVector = transform.position - _camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        _dragging = false;
    }
}
