using UnityEngine;
using UnityEngine.EventSystems;
using Yarn.Unity;

public class Character4_Handler : MonoBehaviour, IPointerClickHandler
{
    public DialogueRunner runDialogue;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Character 4 ");
        runDialogue.StartDialogue("Character4");

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
