using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory inventory;
    public Dictionary<string, int> materials; // created dictionary storing material types and amount
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add_material(string Material_name, int num){ // add material and the amount to the inventory, triggered by Material_Item.collect(). 
        materials[Material_name] += num;
    }
}
