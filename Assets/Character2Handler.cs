using UnityEngine;
using UnityEngine.EventSystems;
using Yarn.Unity;

public class Character2Handler : MonoBehaviour, IPointerClickHandler
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
        Debug.Log("Character 2 ");
        runDialogue.StartDialogue("Character2");
    }
}
