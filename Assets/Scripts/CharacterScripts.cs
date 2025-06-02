using UnityEngine;
using UnityEngine.EventSystems;
using Yarn.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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

        if (inputString == "thomas1" || inputString == "thomas2" || inputString == "thomas3" || inputString == "thomas4")
        {
            isCharacter1Done = true;
        }
        else if (inputString == "starboy" || inputString == "starboy2" || inputString == "starboy3" || inputString == "starboy4")
        {
            isCharacter2Done = true;
        }
        else if (inputString == "luci" || inputString == "luci2" || inputString == "luci3" || inputString == "luci4")
        {
            isCharacter3Done = true;

        }
        else if (inputString == "cheesequeen" || inputString == "cheesequeen2" || inputString == "cheesequeen3" || inputString == "cheesequeen4")
        {
            isCharacter4Done = true;
        }
    }

    // List<GameObject> characters = { character1, character2, character3, character4 };

    //Make a boolean for each round and set it equal to true once each character is done with their dialogue

    public void enterDialogue(GameObject currentCharacter)
    {
        currentCharacter.transform.position = new Vector3(0, 0.69f, 0);
        
        currentCharacter.transform.rotation = new Quaternion(0, 0, 0,0);
        main_camera.orthographicSize = 4.5f;

        if (currentCharacter == characters[2])
        {
            currentCharacter.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else if (currentCharacter == characters[3])
        {
            currentCharacter.transform.localScale = new Vector3(1, 1, 1);

        }
        else
        {
            currentCharacter.transform.localScale = new Vector3(2, 2, 2);

        }

        foreach (GameObject character in characters)
        {
            if (currentCharacter == character)
            {
                character.SetActive(true);
                // Instead of just currentCharacter.name, use scene-character naming convention
                string sceneNumber = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
                string dialogueName = currentCharacter.name + sceneNumber;
                runDialogue.StartDialogue(dialogueName);
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
        Debug.Log("Exit dialogue function is working");

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
            currentCharacter.transform.localScale = new Vector3(1.37f, 1.37f, 1.37f);
            currentCharacter.transform.position = new Vector3(1.12f, 0, 0);
            currentCharacter.transform.rotation = new Quaternion(0, 0, 0, 0);

            returnCharacters();

        }
        else if (currentCharacter == characters[3] && isCharacter4Done == true)
        {
            main_camera.orthographicSize = 5f;
            currentCharacter.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
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


    public void Awake()
    {
        characters.Add(GameObject.Find("thomas"));
        characters.Add(GameObject.Find("starboy"));
        characters.Add(GameObject.Find("luci"));
        characters.Add(GameObject.Find("cheesequeen"));

        foreach (GameObject character in characters)
        {
            Button button = character.GetComponent<Button>();
        }
    }
}