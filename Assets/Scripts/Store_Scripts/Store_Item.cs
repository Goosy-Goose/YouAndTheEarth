using UnityEngine;

public class Store_Item : MonoBehaviour
{

    public string promptText;
    public GameObject interactionPrompt;

    GameObject promptObj;
    protected GameObject playerObj;
    protected bool isUnlocked;
    //protected bool playerInCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log("Store_Item " + gameObject.name + " created");
        //DELETE THIS LINE LATER
        setLock(false);
        playerObj = null;
        //playerInCollider = false;
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

        // Debug.Log(playerObj);
        // create a interact prompt object
        if (promptObj == null){
            promptObj = Instantiate(interactionPrompt, new Vector3(0, 0, 0), Quaternion.identity);

            promptObj.GetComponent<TextMesh>().text = promptText;
            promptObj.transform.position = new Vector3(transform.position.x, 
                                                       transform.position.y + 1.1f, 
                                                       0);
        }
        //playerInCollider = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        /* Debug.Log("Collider on " + other.gameObject.name + 
         * " exited collider on " + gameObject.name);*/
        Destroy(promptObj);
        playerObj = null;
    }

    protected virtual void doInteraction()
    {
        Debug.Log("Store Item interaction");
    }

    public void setLock(bool lockStatus) { 
        isUnlocked = lockStatus;
        if (isUnlocked) { GetComponent<SpriteRenderer>().color = Color.white; }
        else { GetComponent<SpriteRenderer>().color = Color.black; }
    }

}
