using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Game_Data
{
    public Dictionary<string, int> inventoryMaterials;
    // things to save:
    // player inventory
    // the unlock status of all storeItems (list of gameobjs w the Store_Buyables script)
    // in the StoreManager (gameobj) Store_Manager (script)

    public Game_Data()
    {
        this.inventoryMaterials = new Dictionary<string, int>()
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
    }

}
