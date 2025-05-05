using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPage : MonoBehaviour
{
    public void OnPlayButton(){
        Data_Persistence_Manager.instance.NewGame();
        SceneManager.LoadScene(sceneName: "Store");
    }

    public void OnLoadButton()
    {
        Data_Persistence_Manager.instance.LoadGame();
        SceneManager.LoadScene(sceneName: "Store");
    }

    public void OnQuitButton(){
        Application.Quit();
    }
}