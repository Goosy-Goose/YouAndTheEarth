using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Manager : MonoBehaviour
{
    public static Menu_Manager instance;
    public GameObject pauseMenu;
    public GameObject buyablesMenu;
    public GameObject levelSelectMenu;
    public GameObject exitLvlMenu;
    public GameObject inventoryMenu;

    private bool isAMenuOpen;
    [SerializeField] private List<GameObject> menusList;


    private void Start()
    {

        if (pauseMenu) { menusList.Add(pauseMenu); }
        if (buyablesMenu) { menusList.Add(buyablesMenu); }
        if (levelSelectMenu) { menusList.Add(levelSelectMenu); }
        if (exitLvlMenu) { menusList.Add(exitLvlMenu); }
        if (inventoryMenu) { menusList.Add(inventoryMenu); }
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

        // SUPER MEGA SCUFFED ESCAPE KEY SHENANIGANS (its the same code for both of them, im just too lazy to make it good
        // if escape key pressed, either close all menus or open the pause menu
        if (Store_Manager.instance && Store_Manager.instance.playerInput.actions["Menu"].WasPressedThisFrame())
        {
            if (!isAMenuOpen) { openMenu(pauseMenu); }
            else{ closeAllMenus(); }
        }
        else if (Level_Manager.instance && Level_Manager.instance.playerInput.actions["Menu"].WasPressedThisFrame())
        {
            if (!isAMenuOpen) { openMenu(pauseMenu); }
            else { closeAllMenus(); }
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