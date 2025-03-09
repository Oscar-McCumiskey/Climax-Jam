using UnityEngine;
using UnityEngine.Serialization;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource soundObject;
    [SerializeField] private SFXClips[] audioClips;
    public float pitchModifier = 1;

    [System.Serializable]
    public class SFXClips
    {
        public SFX soundName;
        public AudioClip clip;
    }

    public enum SFX
    {
        ROCKET_LAUNCH,
        ROCKET_LAND,
        ROCKET_CRASH,
        
        CLICK
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void PlayAudioClip(AudioClip clip, Transform transform, float volume)
    {
        // Spawn Object
        AudioSource audioSource = Instantiate(soundObject, transform.position, Quaternion.identity);

        // Assign Audio Clip
        audioSource.clip = clip;

        // Change Volume
        audioSource.volume = volume;

        // Change Pitch
        audioSource.pitch = pitchModifier;

        // Play Audio
        audioSource.Play();

        // destroy object on clip end
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }

    public void PlaySound(SFX audioClip, Transform transform, float volume)
    {
        // Spawn Object
        AudioSource audioSource = Instantiate(soundObject, transform.position, Quaternion.identity);

        // Assign Audio Clip
        audioSource.clip = GetAudioClip(audioClip);

        // Change Volume
        audioSource.volume = volume;

        // Change Pitch
        audioSource.pitch = pitchModifier;

        // Play Audio
        audioSource.Play();

        // destroy object on clip end
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }

    public void PlayRandomSound(SFX[] audioClip, Transform transform, float volume)
    {
        // Get random clip
        int rand = Random.Range(0, audioClip.Length);

        // Spawn Object
        AudioSource audioSource = Instantiate(soundObject, transform.position, Quaternion.identity);

        // Assign Audio Clip
        audioSource.clip = GetAudioClip(audioClip[rand]);

        // Change Volume
        audioSource.volume = volume;

        // Play Audio
        audioSource.Play();

        // Destroy object on clip end
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }

    private AudioClip GetAudioClip(SFX sound)
    {
        foreach (SFXClips clip in audioClips)
        {
            if (clip.soundName == sound)
            {
                return clip.clip;
            }
        }

        return null;
    }
}
