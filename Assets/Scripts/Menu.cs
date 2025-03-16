using UnityEngine;
using UnityEngine.InputSystem;


public class Menu : MonoBehaviour
{
    InputAction menuAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuAction = InputSystem.actions.FindAction("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        bool menuValue = menuAction.IsPressed();

    }
}
