using System;
using UnityEngine;
using UnityEngine.UI;

public class LaunchPad : MonoBehaviour
{
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private float launchVelocity;
    [SerializeField] private float launchCooldown;
    
    [SerializeField] public Button launchButton;

    public bool _canLaunch; 
    private float _launchTimer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _canLaunch = true;
        _launchTimer = launchCooldown;
        
        GameManager.Instance.isLaunching = false;
    }

    private void Update()
    {
        /*if (_launchTimer <= 0)
        {
            _canLaunch = true;
            launchButton.interactable = true;
            GameManager.Instance.isLaunching = false;
        }
        
        _launchTimer -= Time.deltaTime;
        */

        if (Input.GetKeyDown(KeyCode.Space) && _canLaunch)
        {
            Launch();
        }
        if (_canLaunch)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public void Launch()
    {
        if (_canLaunch)
        {
            GetComponent<SpriteRenderer>().enabled = false;

            // remove last trail
            Destroy(GameObject.FindGameObjectWithTag("Trail"));
            
            GameObject rocket = Instantiate(rocketPrefab, transform.position, transform.rotation);
            rocket.GetComponent<Rigidbody2D>().linearVelocity = transform.up * launchVelocity;

            _canLaunch = false;
            _launchTimer = launchCooldown;
            launchButton.interactable = false;
            GameManager.Instance.isLaunching = true;
        }
    }
}
