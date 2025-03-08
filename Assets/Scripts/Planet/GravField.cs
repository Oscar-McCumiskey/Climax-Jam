using UnityEditor.Rendering;
using UnityEngine;

public class GravField : MonoBehaviour
{
    public float gravity;
    [SerializeField] SpriteRenderer gravField;
    [SerializeField] Color weakColour;
    [SerializeField] Color strongColour;

    private void SetColourBasedOnGravity()
    {
        float adjustedGravity = Mathf.Clamp(gravity, 0f, 10f);

        float normalizedGravity = Mathf.InverseLerp(3f,6f, adjustedGravity);

        Color colourBasedOnGrav = Color.Lerp(weakColour, strongColour, normalizedGravity);

        float hue, saturation, value;
        Color.RGBToHSV(colourBasedOnGrav, out hue, out saturation, out value);

        saturation = 0.4f;
        value = 1f;

        colourBasedOnGrav = Color.HSVToRGB(hue, saturation, value);

        colourBasedOnGrav.a = 1f;
        gravField.color = colourBasedOnGrav;
    }

    private void Awake()
    {
        SetColourBasedOnGravity();
    }
}
