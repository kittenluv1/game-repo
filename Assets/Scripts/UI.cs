using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    public GameObject MainMenuPanel; 
    public GameObject SettingsPanel;

    public void Start()
    {
        MainMenuPanel = GameObject.Find("MainMenuPanel");
        SettingsPanel = GameObject.Find("SettingsPanel");
        MainMenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }

    public void ShowMainMenu()
    {
        MainMenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("TestCase");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void ShowSettings()
    {
        MainMenuPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }

    public void ShowCredits()
    {
        MainMenuPanel.SetActive(false);
        SettingsPanel.SetActive(false);
    }
}
