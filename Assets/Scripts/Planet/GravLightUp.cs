using UnityEngine;

public class GravLightUp : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void LightUp(float colourFactor)
    {
        if (spriteRenderer != null) //stops null ref exception
        {
            Color currentColour = spriteRenderer.color;

            spriteRenderer.color = new Color(currentColour.r * colourFactor, currentColour.g * colourFactor, currentColour.b * colourFactor, currentColour.a);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rocket"))
        {
            LightUp(1.2f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rocket"))
        {
            LightUp(0.8f);
        }
    }
}
