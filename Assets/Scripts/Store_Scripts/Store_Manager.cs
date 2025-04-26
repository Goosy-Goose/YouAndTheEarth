using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Store_Manager : MonoBehaviour
{
    public static Store_Manager instance;
    public GameObject playerObj;
    public PlayerInput playerInput;
    public List<GameObject> storeItems;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
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
    private void Update()
    {
        
    }
}
