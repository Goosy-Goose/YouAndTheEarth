using UnityEngine;

public class Store_Item : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // when this obj collides w/ another gameobj? or another collider?
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered " + gameObject.name + " Collider");
        // create a interact prompt object?
    }
}
