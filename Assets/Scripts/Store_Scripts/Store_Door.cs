using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Store_Door : Store_Item
{

    [SerializeField] private List<string> levelNames;
    // uses Store_Item Start() function
    void Start() {

        levelNames = new List<string> { "BeachLevel", "GrassLevel", "ForestLevel" };
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void doInteraction()
    {
        base.doInteraction();

        //SceneManager.LoadScene(sceneName: levelNames[Random.Range(0,4)]);
        // FOR TESTING PURPOSES ONLY:
        SceneManager.LoadScene(sceneName: "BeachLevel");

    }


}
