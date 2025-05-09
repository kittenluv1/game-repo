using UnityEngine;
using UnityEngine.EventSystems;
using Yarn.Unity;

public class Character1Script : MonoBehaviour, IPointerClickHandler
{
    public DialogueRunner runDialogue;
    private RoundsScript roundsScript;


    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject character1 = GameObject.Find("Character1");
        GameObject character2 = GameObject.Find("Character2");
        GameObject character3 = GameObject.Find("Character3");
        GameObject character4 = GameObject.Find("Character4");

        GameObject clickedCharacter = this.gameObject;
        Debug.Log("Character1");
        transform.position = new Vector3(0, 0.69f, 0);
        transform.localScale = new Vector3(3, 3, 3);
        // m_OrthographicCamera.orthographicSize = 1.0f;
        if(clickedCharacter == character1){
            character2.SetActive(false);
            character3.SetActive(false);
            character4.SetActive(false);
        }
        if(clickedCharacter == character2){
            character1.SetActive(false);
            character3.SetActive(false);
            character4.SetActive(false);
        }
        if(clickedCharacter == character3){
            character1.SetActive(false);
            character2.SetActive(false);
            character4.SetActive(false);
        }
        if(clickedCharacter == character4){
            character1.SetActive(false);
            character2.SetActive(false);
            character3.SetActive(false);
        }

        // this.gameObject.SetActive(false);
        // transform.position = new Vector3(-0.03, 0.69, 0);
        // CharacterPosition.x = 0;
        // transform.position = CharacterPosition.x;
        Debug.Log(transform.position);
        // transform.position.x = transform.position.x + 1;
        // transform.position = new Vector3(1.0f, 1.0f, 1.0f);
        runDialogue.StartDialogue(this.gameObject.name);

        roundsScript.roundCounter++;
    }
    }
    void Character1Interrogation (){
        GameObject character1 = GameObject.Find("Character1");

        character1.SetActive(false);

    }
    // void Character2Interrogation (){

    // }
    // void Character3Interrogation (){

    // }
    // void Character4Interrogation (){

    // }
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
    // void OnClick(){
    //     Debug.Log("This is working");
    // }
}
