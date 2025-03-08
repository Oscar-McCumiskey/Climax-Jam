using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeedDegPerSec = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.Euler(0, 0, rotationSpeedDegPerSec * Time.deltaTime);
    }
}
