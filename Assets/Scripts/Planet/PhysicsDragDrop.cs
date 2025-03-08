using System;
using UnityEngine;

public class PhysicsDragDrop : MonoBehaviour
{
    private Camera _camera;
    private Rigidbody2D _rb;
    private Vector2 _offsetVector;

    private bool _dragging;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
    }

    private void FixedUpdate()
    {
        if (_dragging && _camera && !GameManager.Instance.isLaunching)
        {
            Vector2 targetPos = _camera.ScreenToWorldPoint(Input.mousePosition);
            targetPos += _offsetVector;

            _rb.MovePosition(targetPos);
        }
    }

    private void OnMouseDown()
    {
        _dragging = true;
        _offsetVector = transform.position - _camera.ScreenToWorldPoint(Input.mousePosition);
        
        _rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnMouseUp()
    {
        _dragging = false;
        
        _rb.bodyType = RigidbodyType2D.Static;
    }
}
