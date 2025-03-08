using UnityEngine;

public class LaunchPad : MonoBehaviour
{
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private float launchVelocity;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        
        GameObject rocket = Instantiate(rocketPrefab, transform.position, transform.rotation);
        rocket.GetComponent<Rigidbody2D>().linearVelocity =  transform.up * launchVelocity;
    }
}
