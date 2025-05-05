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
        //Debug.Log("Dict: " + string.Join(", ", materials.Select(kv => $"{kv.Key}: {kv.Value}")));
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
            materials = new Dictionary<string, int>()
            {
                {"Cardboard", 0},
                {"Fabric", 0 },
                {"Glass", 0},
                {"Leaves", 0 },
                {"Metal", 0 },
                {"Paper", 0 },
                {"Plastic", 0},
                {"Wood", 0}
            };
            DontDestroyOnLoad(gameObject);
        }
    }

    //public void LoadData(Game_Data data)
    //{
    //    Debug.Log("Inventory is allegedly loading data");
    //    this.materials = data.inventoryMaterials;
    //}
    //public void SaveData(ref Game_Data data)
    //{
    //    data.inventoryMaterials = this.materials;
    //}


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
