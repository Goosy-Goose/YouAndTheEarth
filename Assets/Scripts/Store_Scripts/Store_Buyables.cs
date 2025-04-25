using UnityEngine;

public class Store_Buyables : Store_Item
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInCollider)
        {
            Debug.Log("Player in collider: " + name);
            // if player clicks f, open menu
        }
    }
}
