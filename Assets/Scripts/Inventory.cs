using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory inventory;
    public Dictionary<string, int> materials; // created dictionary storing material types and amount
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        materials = new Dictionary<string, int> { };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (inventory == null)
        {
            inventory = this;
        }
        else
        {
            Destroy(gameObject); // Prevent multiple Store_Managers
        }
    }

    public void Add_material(string Material_name, int num){ // add material and the amount to the inventory, triggered by Material_Item.collect(). 
        if (materials.ContainsKey(Material_name))
        {
            materials[Material_name] += num;
        }
        else
        {
            materials.Add(Material_name, num);
        }
    }
}
