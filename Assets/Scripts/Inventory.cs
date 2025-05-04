using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        Debug.Log("Dict: " + string.Join(", ", materials.Select(kv => $"{kv.Key}: {kv.Value}")));
    }

    private void Awake()
    {
        
        if (inventory != null)
        {
            Destroy(gameObject); // Prevent multiple Store_Managers

        }
        else
        {
            inventory = this;
            materials = new Dictionary<string, int> { };
            DontDestroyOnLoad(gameObject);
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
