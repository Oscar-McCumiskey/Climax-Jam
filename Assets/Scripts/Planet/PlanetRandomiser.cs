using NUnit.Framework;
using UnityEngine;

public class PlanetRandomiser : MonoBehaviour
{
    [SerializeField] private SpriteRenderer baseSpriteRenderer;
    [SerializeField] private SpriteRenderer designSpriteRenderer;
    [SerializeField] private Sprite[] planetVariations;

    private void RandomiseDesign()
    {
        if (planetVariations != null && planetVariations.Length > 0)
        {
            int randomIndex = Random.Range(0, planetVariations.Length);
            
            if (randomIndex >= 0 && randomIndex < planetVariations.Length)
            { 
                designSpriteRenderer.sprite = planetVariations[randomIndex]; 
            }
        }
    }

    private void RandomiseBaseColour()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);

        Color randomColour = new Color(r, g, b);

        baseSpriteRenderer.color = randomColour;
    }

    private void RandomiseDesignColour()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);

        Color randomColour = new Color(r, g, b);

        designSpriteRenderer.color = randomColour;
    }

    private void Awake()
    {
        RandomiseDesign();
        RandomiseBaseColour();
        RandomiseDesignColour();
    }
}
