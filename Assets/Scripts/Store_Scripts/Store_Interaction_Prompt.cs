using UnityEngine;

public class Store_Interaction_Prompt : MonoBehaviour
{

    string promptText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log(name + "prompt text is " + promptText);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        Debug.Log("Destroyed " + gameObject.name);
    }
}
