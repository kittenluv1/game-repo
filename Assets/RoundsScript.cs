using TMPro;
using UnityEngine;

public class RoundsScript : MonoBehaviour
{
    public TextMeshProUGUI roundCounterUI;
    public int roundCounter = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        roundCounterUI.text = "Round: " + roundCounter.ToString();
    }
}
