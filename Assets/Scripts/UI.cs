using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    public GameObject MainMenuPanel; 
    public GameObject SettingsPanel;
    public GameObject CreditsPanel;

    public void Start()
    {
        MainMenuPanel = GameObject.Find("MainMenuPanel");
        SettingsPanel = GameObject.Find("SettingsPanel");
        CreditsPanel = GameObject.Find("CreditsPanel");
        MainMenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
    }

    public void ShowMainMenu()
    {
        MainMenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
    }

    public void playGame()
    {
        SceneManager.LoadSceneAsync("CutScene");
    }

    public void ShowSettings()
    {
        MainMenuPanel.SetActive(false);
        SettingsPanel.SetActive(true);
        CreditsPanel.SetActive(false);
    }

    public void ShowCredits()
    {
        MainMenuPanel.SetActive(false);
        SettingsPanel.SetActive(false);
        CreditsPanel.SetActive(true);
    }
}
