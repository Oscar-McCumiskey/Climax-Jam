using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
    }
}
