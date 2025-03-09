using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public void PressSound()
    {
        SoundManager.Instance.PlaySound(SoundManager.SFX.BUTTON_CLICK, transform, 1f);
    }
}
