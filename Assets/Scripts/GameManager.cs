using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public bool isLaunching = false;
    
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
