using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Store_Manager : MonoBehaviour
{
    //public PlayerInput playerInput;
    public List<GameObject> storeItems;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //playerInput.E
        //playerInput.SwitchCurrentActionMap("PlayerGame");
        //print("current player input actionmap: " + playerInput.currentActionMap.name);
        // iterate through storeItems list and set all the unlocked bools
        foreach (GameObject item in storeItems)
        {
            item.GetComponent<Store_Item>().setLock(false); 
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
