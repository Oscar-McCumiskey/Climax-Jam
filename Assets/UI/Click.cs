using UnityEngine;

public class Click : MonoBehaviour
{
    public void Sound()
    {
        SoundManager.Instance.PlaySound(SoundManager.SFX.CLICK, transform, 1f);
    }
}
