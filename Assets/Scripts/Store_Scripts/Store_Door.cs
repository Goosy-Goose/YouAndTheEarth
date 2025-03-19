using UnityEngine;

public class Store_Door : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Door");
    }

    // Update is called once per frame
    void Update()
    {

    }

    // when this obj collides w/ another gameobj? or another collider?
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered Door Collider");
    }
}
