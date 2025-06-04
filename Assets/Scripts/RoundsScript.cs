using TMPro;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.Video;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;

public class RoundsScript : MonoBehaviour
{
    public TextMeshProUGUI roundCounterUI;
    public DialogueRunner dialogueRunner;
    public VideoPlayer beginningCutscene;
    public VideoPlayer endCutscene;
    public RawImage rawImage;
    public int roundCounter = 1;
    public int numRounds = 4;
    public GameObject suspectListUI;
    public ToggleGroup suspectList;
    public Character1Script characterScripts;
    public Button continueButton;
    public GameObject realSuspect;
    public TextMeshProUGUI winOrLoseText;
    [SerializeField]
    private GameObject currentSuspect;

    public Dictionary<Toggle, GameObject> toggleToCharacterMap = new Dictionary<Toggle, GameObject>();

    void Awake()
    {
        dialogueRunner.onDialogueComplete.AddListener(onDialogueCompleteListener);
        playCutScene(); 
    }

    void Start()
    {

        // update toggle values
        GameObject[] characters = characterScripts.characters.ToArray();
        Toggle[] toggles = suspectList.GetComponentsInChildren<Toggle>();
        for (int i = 0; i < toggles.Length && i < characters.Length; i++)
        {
            Toggle toggle = toggles[i];
            GameObject character = characters[i];

            // Use Text (legacy UI)
            Text label = toggle.GetComponentInChildren<Text>();
            if (label != null)
            {
                label.text = character.name;
            }
            // Add mapping
            toggleToCharacterMap[toggle] = character;

            // Add listener to assign currentSuspect when toggle is selected
            toggle.onValueChanged.AddListener((isOn) =>
            {
                if (isOn)
                {
                    currentSuspect = character;
                    Debug.Log("Current suspect: " + currentSuspect.name);
                }
                else if (currentSuspect == character)
                {
                    currentSuspect = null;
                    Debug.Log("Current suspect reset to null");
                }
            });
        }

        // continue button
        continueButton.onClick.AddListener(() =>
        {
            roundCounter++;
            if (roundCounter > numRounds)
            {
                if (currentSuspect != null)
                {
                    suspectListUI.SetActive(false);
                    endGame();
                    return;
                }
                else
                {
                    Debug.Log("Please select a suspect.");
                    return;
                }
            }
            suspectListUI.SetActive(false);
            roundCounterUI.text = "Round: " + roundCounter.ToString();
        });
    }

    void playCutScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        string cutscenePath = System.IO.Path.Combine(Application.streamingAssetsPath, sceneName + ".mp4");
        Debug.Log("Cutscene path:" + cutscenePath); 
        beginningCutscene.url = cutscenePath;
        beginningCutscene.loopPointReached += (VideoPlayer vp) =>
        {
            beginningCutscene.Stop();
            rawImage.gameObject.SetActive(false);
        };
        beginningCutscene.prepareCompleted += (VideoPlayer vp) =>
        {
            rawImage.gameObject.SetActive(true);
            rawImage.texture = beginningCutscene.texture;
            beginningCutscene.Play();
        };
        beginningCutscene.Prepare();
    }

    void onDialogueCompleteListener()
    {
        Debug.Log("Dialogue complete");
        suspectListUI.SetActive(true);
    }

    void endGame()
    {
        Debug.Log("end game called");

        if (currentSuspect == realSuspect)
        {
            Debug.Log("You chose: " + currentSuspect.name + "\nYou win!");
            winOrLoseText.text = "You chose: " + currentSuspect.name + "\nYou win!";
            winOrLoseText.gameObject.SetActive(true);
            winOrLoseText.enabled = true;
        }
        else
        {
            Debug.Log("You chose: " + currentSuspect.name + "\nYou lose!");
            winOrLoseText.text = "You chose: " + currentSuspect.name + "\nYou lose!";
            winOrLoseText.gameObject.SetActive(true);
            winOrLoseText.enabled = true;
        }
        
        StartCoroutine(UnloadSceneAfterDelay(2f));
    }

    IEnumerator UnloadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("StartScene");
    }
}
