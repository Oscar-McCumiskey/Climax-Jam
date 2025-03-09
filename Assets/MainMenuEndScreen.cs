using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuEndScreen : MonoBehaviour
{
    public void BackToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
