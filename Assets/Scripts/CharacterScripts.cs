using UnityEngine;
using UnityEngine.EventSystems;
using Yarn.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Character1Script : MonoBehaviour
{
    public DialogueRunner runDialogue;
    private RoundsScript roundsScript;

    public List<GameObject> characters;


    List<bool> roundCounter = new List<bool>();

    // Below four booleans are for keeping track of when each dialogue is done 
    bool isCharacter1Done = false;
    bool isCharacter2Done = false;
    bool isCharacter3Done = false;
    bool isCharacter4Done = false;

    public bool[] roundTracker = { true, false };
    public Camera main_camera;
    float main_cameraX, main_cameraY, main_cameraZ;

    //Only boolean function needed
    public void isADialogueDone(string inputString)
    {

        if (inputString == "Character1")
        {
            isCharacter1Done = true;
        }
        else if (inputString == "Character2")
        {
            isCharacter2Done = true;
        }
        else if (inputString == "Character3")
        {
            isCharacter3Done = true;

        }
        else if (inputString == "Character4")
        {
            isCharacter4Done = true;

        }
    }

    // List<GameObject> characters = { character1, character2, character3, character4 };

    //Make a boolean for each round and set it equal to true once each character is done with their dialogue

    public void enterDialogue(GameObject currentCharacter)
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

        if (currentCharacter == characters[0] && isCharacter1Done == true)
        {
            main_camera.orthographicSize = 5f;
            currentCharacter.transform.localScale = new Vector3(2, 2, 2);
            currentCharacter.transform.position = new Vector3(-4, -0.55f, 0);
            returnCharacters();

        }
        else if (currentCharacter == characters[1] && isCharacter2Done == true)
        {
            main_camera.orthographicSize = 5f;
            currentCharacter.transform.localScale = new Vector3(2, 2, 2);
            currentCharacter.transform.position = new Vector3(-1.43f, 0.66f, 0);
            returnCharacters();
        }
        else if (currentCharacter == characters[2] && isCharacter3Done == true)
        {
            main_camera.orthographicSize = 5f;
            currentCharacter.transform.localScale = new Vector3(2, 2, 2);
            currentCharacter.transform.position = new Vector3(1.33f, 0.73f, 0);
            returnCharacters();

        }
        else if (currentCharacter == characters[3] && isCharacter4Done == true)
        {
            main_camera.orthographicSize = 5f;
            currentCharacter.transform.localScale = new Vector3(2, 2, 2);
            currentCharacter.transform.position = new Vector3(3.94f, -0.69f, 0);
            returnCharacters();

        }
    }

    //this function will determine the outcome of the game or will play a part it in
    // There will be a game over screen and a victory scene 
    // After you select who you think is the culprit, if you are correct then load the victory scene if not load the game over screen
    // The final game over screen will have the character who you picked as the culprit either in jail or ruling the world or something if you lost
    // We can hardcode each option but so basically 
    public bool isGameOver(GameObject finalCharacter)
    {
        if (isCharacter1Done && isCharacter2Done && isCharacter3Done && isCharacter4Done)
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

        bool currentStateOfGame = isGameOver(clickedCharacter);
        if (currentStateOfGame == false)
        {
            if (clickedCharacter == characters[0] && isCharacter1Done == false)
            {
                enterDialogue(clickedCharacter);
            }
            else if (clickedCharacter == characters[1] && isCharacter2Done == false)
            {
                enterDialogue(clickedCharacter);
            }
            else if (clickedCharacter == characters[2] && isCharacter3Done == false)
            {
                enterDialogue(clickedCharacter);
            }
            else if (clickedCharacter == characters[3] && isCharacter4Done == false)
            {
                enterDialogue(clickedCharacter);
            }
            else
            {
                exitDialogue(clickedCharacter);
            }
        }
        else
        {
            //Enter the game over screen
            // scene.
        }

    }


    public void Start()
    {
        characters.Add(GameObject.Find("Character1"));
        characters.Add(GameObject.Find("Character2"));
        characters.Add(GameObject.Find("Character3"));
        characters.Add(GameObject.Find("Character4"));

        foreach (GameObject character in characters)
        {
            Button button = character.GetComponent<Button>();
        }
    }
}