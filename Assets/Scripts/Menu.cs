using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject menuUI;

    void Start()
    {
        menuUI.SetActive(false);
    }

    public void Pause()
    {
        menuUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        menuUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void GoStartPage()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}