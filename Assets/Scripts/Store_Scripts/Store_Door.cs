using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Store_Door : Store_Item
{

    private GameObject levelSelectMenu;
    // uses Store_Item Start() function
    void Start() 
    {
        levelSelectMenu = Menu_Manager.instance.levelSelectMenu;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void doInteraction()
    {
        base.doInteraction();

        Menu_Manager.instance.openMenu(levelSelectMenu);
            //SceneManager.LoadScene(sceneName: levelNames[Random.Range(0,4)]);
            // FOR TESTING PURPOSES ONLY:
            //SceneManager.LoadScene(sceneName: "BeachLevel");

    }


}
