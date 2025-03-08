using UnityEngine;
using UnityEngine.UI;

public class BlinkScript : MonoBehaviour
{
    public Image theImage;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RandomizeTransparency();
    }

    public void RandomizeTransparency()
    {
        Color currentColor = theImage.color;
        float randomAlpha = Random.Range(0.2f, 1f);
        Color newColor = new Color(currentColor.r, currentColor.g, currentColor.b, randomAlpha);
        theImage.color = newColor;
    }
}
