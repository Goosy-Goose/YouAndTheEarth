using UnityEngine;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    public GameObject menuUI;

    private InputAction menuAction;
    private bool isMenuOpen = false;

    void Start()
    {
        menuAction = InputSystem.actions.FindAction("Menu");
        menuUI.SetActive(false);
    }

    void Update()
    {
        if (menuAction.WasPressedThisFrame())
        {
            isMenuOpen = !isMenuOpen;
            menuUI.SetActive(isMenuOpen);
            Time.timeScale = isMenuOpen ? 0 : 1;
        }
    }

    public void ResumeGame()
    {
        isMenuOpen = false;
        menuUI.SetActive(false);
        Time.timeScale = 1;
    }
}