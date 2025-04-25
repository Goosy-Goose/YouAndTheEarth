using UnityEngine;

public class Store_Buyables : Store_Item
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void doInteraction()
    {
        base.doInteraction();
        Debug.Log("Child Interaction");
    }
}
