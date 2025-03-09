using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DeathCounter : MonoBehaviour
{
    [SerializeField] TMP_Text deathCounterText;
    [SerializeField] int deathCount;

    private void Awake()
    {
        deathCount = 0;
    }

    public void UpdateDeaths()
    {
        deathCount++;
        deathCounterText.text = deathCount.ToString();
    }
}
