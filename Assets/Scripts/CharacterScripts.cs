using UnityEngine;
using UnityEngine.EventSystems;
using Yarn.Unity;

// public class myFunction : MonoBehaviour
// {
//     // Debug.Log("custom function is working");
// }

public class Character1Script : MonoBehaviour, IPointerClickHandler
{
    public DialogueRunner runDialogue;
    private RoundsScript roundsScript;

    bool character1InterrogationState = false;
    bool character2InterrogationState = false;
    bool character3InterrogationState = false;
    bool character4InterrogationState = false;

    public Camera main_camera;

    float main_cameraX, main_cameraY, main_cameraZ;

    bool DialogueState = false;
    public void isDialogueDone()
    {
        Debug.Log("Dialogue for a character has finished");
        DialogueState = true;
        // return DialogueState;
    }
    public GameObject character1;
    //  = GameObject.Find("Character1");
    public GameObject character2;
    // = GameObject.Find("Character2");
    public GameObject character3;
    // = GameObject.Find("Character3");
    public GameObject character4;
    // = GameObject.Find("Character4");

    public void OnPointerClick(PointerEventData eventData)
    {



        GameObject clickedCharacter = this.gameObject;
        Debug.Log(clickedCharacter);
        Debug.Log(character1);
        Debug.Log(character2);
        Debug.Log(character3);
        Debug.Log(character4);
        transform.position = new Vector3(0, 0.69f, 0);
        transform.localScale = new Vector3(3, 3, 3);
        // m_OrthographicCamera.orthographicSize = 1.0f;


        if (main_camera)
        {
            main_camera.orthographicSize = 4.5f;
        }
        // if (character1.activeInHierarchy)
        // {
        //     Debug.Log("Character1 is not deactivated");
        // }


        if (clickedCharacter == character1 && character1InterrogationState == false)
        {

            DialogueState = false;
            character1InterrogationState = true;
            // Code below will only work once then not again because character will not exist
            character2.SetActive(false);
            character3.SetActive(false);
            character4.SetActive(false);
            runDialogue.StartDialogue(this.gameObject.name);

        }
        else
        
        if (clickedCharacter == character2 && character2InterrogationState == false)
        {

            DialogueState = false;
            character2InterrogationState = true;
            character1.SetActive(false);
            character3.SetActive(false);
            character4.SetActive(false);
            runDialogue.StartDialogue(this.gameObject.name);
        }
        else if (clickedCharacter == character3 && character3InterrogationState == false)
        {
            DialogueState = false;
            character3InterrogationState = true;
            character1.SetActive(false);
            character2.SetActive(false);
            character4.SetActive(false);
            runDialogue.StartDialogue(this.gameObject.name);

        }
        else if (clickedCharacter == character4 && character4InterrogationState == false)
        {

            DialogueState = false;
            character4InterrogationState = true;
            character1.SetActive(false);
            character2.SetActive(false);
            character3.SetActive(false);
            runDialogue.StartDialogue(this.gameObject.name);

        }

        //Once the dialogue is done then we should be able to click again to return to the normal position
        if (DialogueState &&
        (character1InterrogationState | character2InterrogationState | character3InterrogationState | character4InterrogationState)){
        Debug.Log("Dialogue State(bool): " + DialogueState);
        Debug.Log("character2InterrogationState State(bool): " + character2InterrogationState);
            // Debug.Log("Dialogue state conditional for character 2");
            main_camera.orthographicSize = 5f;
            transform.localScale = new Vector3(2, 2, 2);
            if (character1InterrogationState)
            {
                transform.position = new Vector3(-4, -0.55f, 0);

                character2.SetActive(true);
                character3.SetActive(true);
                character4.SetActive(true);
            }
            else if (character2InterrogationState)
            {
                transform.position = new Vector3(-1.43f, 0.66f, 0);

                character1.SetActive(true);
                character3.SetActive(true);
                character4.SetActive(true);
            }
            else if (character3InterrogationState)
            {
                transform.position = new Vector3(1.33f, 0.73f, 0);
                character1.SetActive(true);
                character2.SetActive(true);
                character4.SetActive(true);
            }
            else if (character4InterrogationState)
            {
                transform.position = new Vector3(3.94f, -0.69f, 0);

                character1.SetActive(true);
                character2.SetActive(true);
                character3.SetActive(true);
            }
        }

       

        // roundsScript.roundCounter++;
    }

    // void Character1Interrogation (){
    //     GameObject character1 = GameObject.Find("Character1");

    //     character1.SetActive(false);

    // }
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
