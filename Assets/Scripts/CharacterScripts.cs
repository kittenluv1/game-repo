using UnityEngine;
using UnityEngine.EventSystems;
using Yarn.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.InputSystem;  // 1. The Input System "using" statement
// public class myFunction : MonoBehaviour
// {
//     // Debug.Log("custom function is working");
// }

public class Character1Script : MonoBehaviour
{
    public DialogueRunner runDialogue;
    private RoundsScript roundsScript;

    public List<GameObject> characters;

    List<bool> roundCounter = new List<bool>();

    


    bool character1InterrogationState = false;
    bool character2InterrogationState = false;
    bool character3InterrogationState = false;
    bool character4InterrogationState = false;

    // roundCounter.Add(true);


    //If you put each of the character interrogation states in an array then you can match the character number with the index of the character
    // interrogation statea and that way check if the character you clicked on has been clicked on before without if statements
    // List<bool> roundTracker = {character1InterrogationState, character2InterrogationState, character3InterrogationState, character4InterrogationState};

    public bool[] roundTracker = { true, false };
    public Camera main_camera;
    float main_cameraX, main_cameraY, main_cameraZ;

    // bool DialogueState = false;
    public void isCharacter1DialogueDone()
    {
        Debug.Log("Dialogue for a character has finished");
        // DialogueState = true;
        character1InterrogationState = true;
        // return DialogueState;
    }
    public void isCharacter2DialogueDone()
    {
        Debug.Log("Dialogue for a character has finished");
        character2InterrogationState = true;
        // DialogueState = true;
        // return DialogueState;
    }
    public void isCharacter3DialogueDone()
    {
        Debug.Log("Dialogue for a character has finished");
        character3InterrogationState = true;
        // DialogueState = true;
        // return DialogueState;
    }
    public void isCharacter4DialogueDone()
    {
        Debug.Log("Dialogue for a character has finished");
        character4InterrogationState = true;
        // DialogueState = true;
        // return DialogueState;
    }
    // List<GameObject> characters = { character1, character2, character3, character4 };
   
    //Make a boolean for each round and set it equal to true once each character is done with their dialogue
    
    public void enterDialogue( GameObject currentCharacter)
    {
        currentCharacter.transform.position = new Vector3(0, 0.69f, 0);
        currentCharacter.transform.localScale = new Vector3(3, 3, 3);
        main_camera.orthographicSize = 4.5f;

         foreach (GameObject character in characters)
        {
            if (currentCharacter == character)
            {
                character.SetActive(true);
                runDialogue.StartDialogue(currentCharacter.name);
            }
            else
            {
                character.SetActive(false);
            }

        }
        
        
    }
    public void returnCharacters()
    {
         foreach (GameObject character in characters)
        {
                character.SetActive(true);
            }

        }
    
    public void exitDialogue(GameObject currentCharacter)
    {
        main_camera.orthographicSize = 5f;
        currentCharacter.transform.localScale = new Vector3(2, 2, 2);
    if (currentCharacter == characters[0] && character1InterrogationState == true)
    {
        currentCharacter.transform.position = new Vector3(-4, -0.55f, 0);
        returnCharacters();

    }
    else if (currentCharacter == characters[1] && character2InterrogationState == true)
    {
        currentCharacter.transform.position = new Vector3(-1.43f, 0.66f, 0);
        returnCharacters();
    }
    else if (currentCharacter == characters[2] && character3InterrogationState == true)
    {
        currentCharacter.transform.position = new Vector3(1.33f, 0.73f, 0);
        returnCharacters();

    }
    else if (currentCharacter == characters[3] && character4InterrogationState == true)
    {
        currentCharacter.transform.position = new Vector3(3.94f, -0.69f, 0);
        returnCharacters();

    }
    }
     public bool isGameOver(GameObject finalCharacter)
    {
        if (character1InterrogationState && character2InterrogationState && character3InterrogationState && character4InterrogationState)
        {
            exitDialogue(finalCharacter);
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Character1Clicked(GameObject clickedCharacter)
    {
        // Debug.Log(roundTracker[0]);



        // Debug.Log("CHARACTER1 IS CLICKED ON");
        // Debug.Log(this.gameObject);
        Debug.Log(character1InterrogationState);

        bool currentStateOfGame = isGameOver(clickedCharacter);
        // Debug.Log(characters[0].name);
        if (currentStateOfGame == false)
        {
            // if (clickedCharacter.name && character1InterrogationState != true) {
            if (clickedCharacter == characters[0] && character1InterrogationState == false)
            {
                enterDialogue(clickedCharacter);
            }
            else if (clickedCharacter == characters[1] && character2InterrogationState == false)
            {
                enterDialogue(clickedCharacter);
            }
            else if (clickedCharacter == characters[2] && character3InterrogationState == false)
            {
                enterDialogue(clickedCharacter);
            }
            else if (clickedCharacter == characters[3] && character4InterrogationState == false)
            {
                enterDialogue(clickedCharacter);
            }
            else
            {
                exitDialogue(clickedCharacter);
            }
            // }
        }
        else
        {
            //Enter the game over screen
            // scene.
        }
        // Debug.Log(characters[0]);
        // Debug.Log(characters[1]);
        // Debug.Log(characters[2]);
        // Debug.Log(characters[3]);

    }


    public void Start()
{
    foreach (GameObject character in characters)
    {
        Button button = character.GetComponent<Button>();
        // button.onClick.AddListener(onPointerClick);
    }
}
    
    // public void Character1InterrogationPhase()
    // {
    //     enterDialogue();
        
        
    // }
    // public void Character2InterrogationPhase()
    // {
    //     enterDialogue();
        
    // }
    // public void Character3InterrogationPhase()
    // {
    //     enterDialogue();
        

    // }
    // public void Character4InterrogationPhase()
    // {

    //     enterDialogue();
        
    // }

    private GameObject character1;
    //  = GameObject.Find("Character1");
    public GameObject character2;
    // = GameObject.Find("Character2");
    public GameObject character3;
    // = GameObject.Find("Character3");
    public GameObject character4;
    // = GameObject.Find("Character4");
    
    

    public void onPointerClick(PointerEventData eventData)
    {
        GameObject clickedCharacter = this.gameObject;
        Debug.Log(clickedCharacter);
        Debug.Log("The clicked character above has came from CharacterScripts");

        // m_OrthographicCamera.orthographicSize = 1.0f;


        if (main_camera)
        {
            main_camera.orthographicSize = 4.5f;
        }
        // if (character1.activeInHierarchy)
        // {
        //     Debug.Log("Character1 is not deactivated");
        // }


       



        // if (clickedCharacter == character1 && character1InterrogationState == false)
        // {

        //     DialogueState = false;
        //     character1InterrogationState = true;
        //     // Code below will only work once then not again because character will not exist
        //     character2.SetActive(false);
        //     character3.SetActive(false);
        //     character4.SetActive(false);
        //     runDialogue.StartDialogue(this.gameObject.name);

        // }
        // else

        //     if (clickedCharacter == character2 && character2InterrogationState == false)
        // {

        //     DialogueState = false;
        //     character2InterrogationState = true;
        //     character1.SetActive(false);
        //     character3.SetActive(false);
        //     character4.SetActive(false);
        //     runDialogue.StartDialogue(this.gameObject.name);
        // }
        // else if (clickedCharacter == character3 && character3InterrogationState == false)
        // {
        //     DialogueState = false;
        //     character3InterrogationState = true;
        //     character1.SetActive(false);
        //     character2.SetActive(false);
        //     character4.SetActive(false);
        //     runDialogue.StartDialogue(this.gameObject.name);

        // }
        // else if (clickedCharacter == character4 && character4InterrogationState == false)
        // {

        //     DialogueState = false;
        //     character4InterrogationState = true;
        //     character1.SetActive(false);
        //     character2.SetActive(false);
        //     character3.SetActive(false);
        //     runDialogue.StartDialogue(this.gameObject.name);

        // }

        // //Once the dialogue is done then we should be able to click again to return to the normal position
        // if (DialogueState &&
        // (character1InterrogationState | character2InterrogationState | character3InterrogationState | character4InterrogationState))
        // {
        //     Debug.Log("Dialogue State(bool): " + DialogueState);
        //     Debug.Log("character2InterrogationState State(bool): " + character2InterrogationState);
        //     // Debug.Log("Dialogue state conditional for character 2");
        //     main_camera.orthographicSize = 5f;
        //     transform.localScale = new Vector3(2, 2, 2);
        //     if (character1InterrogationState)
        //     {
        //         transform.position = new Vector3(-4, -0.55f, 0);

        //         character2.SetActive(true);
        //         character3.SetActive(true);
        //         character4.SetActive(true);
        //     }
        //     else if (character2InterrogationState)
        //     {
        //         transform.position = new Vector3(-1.43f, 0.66f, 0);

        //         character1.SetActive(true);
        //         character3.SetActive(true);
        //         character4.SetActive(true);
        //     }
        //     else if (character3InterrogationState)
        //     {
        //         transform.position = new Vector3(1.33f, 0.73f, 0);
        //         character1.SetActive(true);
        //         character2.SetActive(true);
        //         character4.SetActive(true);
        //     }
        //     else if (character4InterrogationState)
        //     {
        //         transform.position = new Vector3(3.94f, -0.69f, 0);

        //         character1.SetActive(true);
        //         character2.SetActive(true);
        //         character3.SetActive(true);
        //     }
        // }



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
