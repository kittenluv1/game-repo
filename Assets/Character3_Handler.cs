using UnityEngine;
using UnityEngine.EventSystems;
using Yarn.Unity;

public class Character3_Handler : MonoBehaviour, IPointerClickHandler
{
    public DialogueRunner runDialogue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Character 3 ");
        runDialogue.StartDialogue("Character3");
    }
}
