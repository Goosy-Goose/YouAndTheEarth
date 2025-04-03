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

    // called when this obj collides w/ another gameobj with  collider
    void OnTriggerEnter2D(Collider2D other)
    {
        /*Debug.Log("Entered " + gameObject.name + " Collider");*/
        // create a interact prompt object
        if (promptObj == null){
            promptObj = Instantiate(interactionPrompt, new Vector3(0, 0, 0), Quaternion.identity);
            promptObj.GetComponent<TextMesh>().text = promptText;
            promptObj.transform.position = new Vector3(transform.position.x, 
                                                       transform.position.y + 1.1f, 
                                                       0);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        /* Debug.Log("Collider on " + other.gameObject.name + 
         * " exited collider on " + gameObject.name);*/
        Destroy(promptObj);
    }
}
