using UnityEngine;

public class RocketTrail : MonoBehaviour
{
    [SerializeField] private float updateInterval = 1f / 30f;
    
    private Transform _rocketTransform;
    private float _updateTimer;
    private LineRenderer _lr;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _lr = gameObject.GetComponent<LineRenderer>();
        _lr.positionCount = 1;
        _lr.SetPosition(0, transform.position);
        
        _updateTimer = updateInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (_lr && _updateTimer <= 0 && _rocketTransform)
        {
            _lr.positionCount += 1;
            _lr.SetPosition(_lr.positionCount - 1, _rocketTransform.position);
            
            _updateTimer = updateInterval;
        }
        
        _updateTimer -= Time.deltaTime;
    }

    public void SetRocketTransform(Transform rocketTransform)
    {
        _rocketTransform = rocketTransform;
    }
}
