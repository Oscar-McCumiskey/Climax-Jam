using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    private bool isOpen;

    private void Awake()
    {
        menuPanel.SetActive(false);
        isOpen = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MainMenu();
        }
    }

    private void MainMenu()
    {
        isOpen = !isOpen;
        menuPanel.SetActive(isOpen);
    }
}
