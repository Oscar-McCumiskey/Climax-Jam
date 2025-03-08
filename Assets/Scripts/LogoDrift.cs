using UnityEngine;

public class LogoDrift : MonoBehaviour
{

    private float moveSpeed = 0.1f; // Adjust for desired movement speed
 
    private RectTransform _rectTransform;
    private Vector2 _currentDirection;

    private float rotationSpeed = 0.03f; // Adjust the speed of rotation
    private float rotationRange = 360f; // Adjust the range of random rotation

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        PickDirection();
    }

    // Update is called once per frame
    void Update()
    {
        _rectTransform.anchoredPosition += _currentDirection * moveSpeed * Time.deltaTime;
        Vector3 currentRotation = _rectTransform.eulerAngles;
        currentRotation.z += Random.Range(-rotationRange, rotationRange) * Time.deltaTime * rotationSpeed;
        _rectTransform.eulerAngles = currentRotation;
    }

    void PickDirection()
    {
        _currentDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
