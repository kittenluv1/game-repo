using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;


using UnityEngine.InputSystem;  // 1. The Input System "using" statement

public class Character_Events : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private UnityEvent<GameObject> _clicked;

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject character = this.gameObject;
        _clicked.Invoke(this.gameObject);
    }
    
}
