using TMPro;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.Video;
using UnityEngine.UI;

public class RoundsScript : MonoBehaviour
{
    public TextMeshProUGUI roundCounterUI;
    public DialogueRunner dialogueRunner;
    public VideoPlayer videoPlayer; 
    public RawImage rawImage;
    public int roundCounter = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        dialogueRunner.onDialogueComplete.AddListener(onDialogueCompleteListener);
    }

    void Start()
    {
        // // cutscene
        videoPlayer.loopPointReached += (VideoPlayer vp) =>
        {
            Debug.Log("video ended");
            videoPlayer.Stop();
            rawImage.gameObject.SetActive(false);
        };
        videoPlayer.prepareCompleted += (VideoPlayer vp) =>
        {
            rawImage.gameObject.SetActive(true);
            rawImage.texture = videoPlayer.texture;
            videoPlayer.Play();
        };
        videoPlayer.Prepare();
    }

    // Update is called once per frame
    void Update()
    {
        roundCounterUI.text = "Round: " + roundCounter.ToString();
    }

    void onDialogueCompleteListener()
    {
        Debug.Log("Dialogue complete");
        roundCounter++;
    }
}
