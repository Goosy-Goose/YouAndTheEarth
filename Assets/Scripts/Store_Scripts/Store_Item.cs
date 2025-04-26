using UnityEngine;

public class Store_Item : MonoBehaviour
{

    public string promptText;
    public GameObject interactionPrompt;

    GameObject promptObj;
    protected GameObject playerObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerObj = null;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // if player.isInteractPressed: open menu
        if (playerObj != null)
        {
            if (playerObj.GetComponent<PlayerController>().isInteractPressed())
            {
                // open menu
                doInteraction();
            }            
        }
    }

    // called when this obj collides w/ another gameobj with  collider
    void OnTriggerEnter2D(Collider2D other)
    {
        playerObj = other.gameObject;

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
        Destroy(promptObj);
        playerObj = null;
    }

    protected virtual void doInteraction()
    {
        Debug.Log("Store Item interaction");
    }

    

}
