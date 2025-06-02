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
        AudioManager.Instance.PlayMusic("Among Us Drip Theme Song Original (Among Us Trap Remix  Amogus Meme Music)");
        AudioManager.Instance.SetMusicVolume(0.5f);
    }

    public void ShowMainMenu()
    {
        MainMenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }

    public void PlayGame1()
    {
        SceneManager.LoadSceneAsync("TestCase");
    }

    public void PlayGame2()
    {
        SceneManager.LoadSceneAsync("TestCase");
    }

    public void PlayGame3()
    {
        SceneManager.LoadSceneAsync("TestCase");
    }
    public void PlayGame4()
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
}
