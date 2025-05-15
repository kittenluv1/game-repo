using UnityEngine;
using UnityEngine.EventSystems;
using Yarn.Unity;

public class Character1Script : MonoBehaviour, IPointerClickHandler
{
    public DialogueRunner runDialogue;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Character1");
        // this.gameObject.SetActive(false);
        // transform.position = new Vector3(-0.03, 0.69, 0);
        runDialogue.StartDialogue(this.gameObject.name);
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
    // void OnClick(){
    //     Debug.Log("This is working");
    // }
}
