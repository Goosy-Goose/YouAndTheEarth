using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Level_Manager : MonoBehaviour
{

    public static Level_Manager instance;
    public GameObject playerObj;
    public PlayerInput playerInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = playerObj.GetComponent<PlayerInput>();
        playerInput.SwitchCurrentActionMap(playerInput.defaultActionMap);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
