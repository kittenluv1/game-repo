using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;


using UnityEngine.InputSystem;  // 1. The Input System "using" statement

public class Character_Events : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private UnityEvent<GameObject> _clicked;
    public delegate void CharacterEventHandler(GameObject e);
    public static event CharacterEventHandler OnMove;

    bool aCharacterClicked = false;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("The click is working for character1");
        Debug.Log(this.gameObject);
        GameObject character = this.gameObject;
        // aCharacterClicked = true;
        // Debug.Log(character);
        // OnMove(this);
        _clicked.Invoke(this.gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {

    // }

    // Update is called once per frame
    // void Update()
    // {

    // }
    


    public void OnClick()
    {
        Debug.Log("OnClick for Character1 is working");
    }
}
