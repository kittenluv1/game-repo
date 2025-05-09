using UnityEngine;
using UnityEngine.EventSystems;
using Yarn.Unity;

public class Character1Script : MonoBehaviour, IPointerClickHandler
{
    public DialogueRunner runDialogue;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Character1");
        runDialogue.StartDialogue("Character1");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
    // void OnClick(){
    //     Debug.Log("This is working");
    // }
}
