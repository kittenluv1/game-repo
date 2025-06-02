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
        SceneManager.LoadSceneAsync("1");
    }

    public void PlayGame2()
    {
        SceneManager.LoadSceneAsync("2");
    }

    public void PlayGame3()
    {
        SceneManager.LoadSceneAsync("3");
    }
    public void PlayGame4()
    {
        SceneManager.LoadSceneAsync("4");
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
