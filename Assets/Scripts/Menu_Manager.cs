using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Manager : MonoBehaviour
{
    public static Menu_Manager instance;
    public GameObject pauseMenu;
    public GameObject buyablesMenu;

    private bool isAMenuOpen;
    [SerializeField] private List<GameObject> menusList;

    private void Start()
    {
        menusList.Add(pauseMenu);
        menusList.Add(buyablesMenu);
        foreach (GameObject menu in menusList) {
            if (menu) { menu.SetActive(false); }
        }
        isAMenuOpen = false;
    }

    private void Update()
    {
        // Checks if any menus are open and sets isAMenuOpen accordingly
        isAMenuOpen = false;
        foreach (GameObject menu in menusList)
        {
            if (menu && menu.activeSelf) {  isAMenuOpen=true; break; }
        }
        
        // if escape key pressed, either close all menus or open the pause menu
        if (Store_Manager.instance.playerInput.actions["Menu"].WasPressedThisFrame())
        {
            if (!isAMenuOpen) { openMenu(pauseMenu); }
            else{ closeAllMenus(); }
        }


        
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Prevent multiple Store_Managers
        }
    }


    public bool openMenu(GameObject menuToOpen)
    {
        if (menuToOpen && isAMenuOpen == false)
        {
            menuToOpen.SetActive(true);
            isAMenuOpen = true;
            Time.timeScale = 0;
            return true;
        }
        return false;
    }

    public void closeMenu(GameObject menuToClose)
    {
        if (menuToClose)
        {
            menuToClose.SetActive(false);
            isAMenuOpen = false;
        }
        Time.timeScale = 1;
    }
    public void closeAllMenus()
    {
        foreach (GameObject menu in menusList)
        {
            closeMenu(menu);
        }
    }
}