using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LvlSelect_Menu : MonoBehaviour
{
    private GameObject levelSelectMenu;

    // only called once
    void Start()
    {
        levelSelectMenu = Menu_Manager.instance.levelSelectMenu;
        levelSelectMenu.SetActive(false);
    }

    void Update()
    {

    }

    public void Pause()
    {
        Menu_Manager.instance.openMenu(levelSelectMenu);
    }

    public void Resume()
    {
        Menu_Manager.instance.closeMenu(levelSelectMenu);
    }

    public void goBeach()
    {
        Resume();
        SceneManager.LoadScene(sceneName: "BeachLevel");
    }
    public void goForest()
    {
        Resume();
        SceneManager.LoadScene(sceneName: "ForestLevel");
    }
    public void goField()
    {
        Resume();
        SceneManager.LoadScene(sceneName: "GrassLevel");
    } 

    public void Unlock()
    {

    }
}
