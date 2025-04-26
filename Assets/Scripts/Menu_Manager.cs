using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Manager : MonoBehaviour
{
    public static Menu_Manager instance;
    public GameObject pauseMenu;
    public GameObject buyablesMenu;

    private bool isAMenuOpen;

    private void Start()
    {
        pauseMenu.SetActive(false);
        buyablesMenu.SetActive(false);
        isAMenuOpen = false;
    }

    private void Update()
    {
        if (Store_Manager.instance.playerInput)
        {
            //Debug.Log(Store_Manager.instance.playerInput.actions["interact"]);
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
}