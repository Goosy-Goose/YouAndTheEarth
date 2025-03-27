using UnityEngine;

public class Store_Item : MonoBehaviour
{

    public string promptText;
    public GameObject interactionPrompt;
    GameObject promptObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Store_Item " + gameObject.name + " created");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // when this obj collides w/ another gameobj? or another collider?
    void OnTriggerEnter2D(Collider2D other)
    {
        /*Debug.Log("Entered " + gameObject.name + " Collider");*/
        // create a interact prompt object?
        if (promptObj == null){
            promptObj = Instantiate(interactionPrompt, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        /* Debug.Log("Collider on " + other.gameObject.name + " exited collider on " + gameObject.name);*/
        Destroy(promptObj);
    }
}
