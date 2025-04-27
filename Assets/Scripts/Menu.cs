using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    private GameObject pauseMenu;

    void Start()
    {
        pauseMenu = Menu_Manager.instance.pauseMenu;
        pauseMenu.SetActive(false);
    }
    // Menus set inactive by the Menu Manager

    public void Pause()
    {
        Menu_Manager.instance.openMenu(pauseMenu);
    }

    public void Resume()
    {
        Menu_Manager.instance.closeMenu(pauseMenu);
    }

    public void GoStartPage()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}