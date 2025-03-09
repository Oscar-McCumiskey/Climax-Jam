using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    [SerializeField] LaunchPad launchPad;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        
        launchPad = GameObject.FindGameObjectWithTag("LaunchPad").GetComponent<LaunchPad>();
        
        Debug.Log(_rb2d.linearVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate towards move direction
        transform.rotation = Quaternion.identity;
        float rotation = Vector2.SignedAngle(Vector2.up, _rb2d.linearVelocity);
        transform.Rotate(0, 0, rotation);

        if (Input.GetKeyDown(KeyCode.R) && GameManager.Instance.isLaunching)
        {
            SelfDestruct();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gravity"))
        {
            // Direction to planet
            Vector2 direction = other.gameObject.transform.position - transform.position;
            direction.Normalize();
            
            Vector2 gravity = direction * other.gameObject.GetComponent<GravField>().gravity;
            
            // Gravity
            _rb2d.AddForce(gravity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SpaceStation"))
        {
            Destroy(gameObject);
            launchPad._canLaunch = true;
            launchPad.launchButton.interactable = true;
            GameManager.Instance.isLaunching = false;
            HandleLevelWin();
        }
        
        if (other.gameObject.CompareTag("Wormhole"))
        {
            transform.position = other.gameObject.GetComponentInParent<Wormhole>().wormholeExit.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstical"))
        {
            Destroy(gameObject);
            launchPad._canLaunch = true;
            launchPad.launchButton.interactable = true;
            GameManager.Instance.isLaunching = false;
        }
    }

    public void HandleLevelWin()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void SelfDestruct()
    {
        Destroy(gameObject);
        launchPad._canLaunch = true;
        launchPad.launchButton.interactable = true;
        GameManager.Instance.isLaunching = false;
    }
}
