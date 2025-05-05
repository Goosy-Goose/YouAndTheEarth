using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store_Buyables : Store_Item
{
    public bool isUnlocked;
    public List<Tuple<string, int>> recipe;


    [SerializeField] private string buyableName;
    [SerializeField] private string description;

    private GameObject buyableMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buyableMenu = Menu_Manager.instance.buyablesMenu;
        setLock(false);
    }

    void Awake() { recipe = new List<Tuple<string, int>>(); }

    protected override void Update()
    {
        base.Update();
    }

    protected override void doInteraction()
    {
        base.doInteraction();
        // open the buyables menu from menu manager? first set all the stuff in it?
        // send in buyableName, description, isUnlocked, image (sprite renderer), and recipe

        if (Menu_Manager.instance.openMenu(buyableMenu))
        {
            var buyComp = buyableMenu.GetComponent<Buyables_Menu>();

            // first set the current buyable object
            buyComp.setCurrBuyable(this);
            // send all the info?
            Sprite buyableSprite = GetComponent<SpriteRenderer>().sprite;
            if (!isUnlocked) { buyComp.setCanUnlock(recipe); }
            buyComp.setMenuInfo(buyableName, isUnlocked, description, buyableSprite, recipe);
        }

    }

    public void setLock(bool lockStatus)
    {
        isUnlocked = lockStatus;
        // sets the sprite to blacked out or not
        if (isUnlocked) { GetComponent<SpriteRenderer>().color = Color.white; }
        else { GetComponent<SpriteRenderer>().color = Color.black; }
    }

    public void addRecipeItem(Tuple<string,int> recipeItem)
    {
        recipe.Add(recipeItem);
        //Debug.Log($"Added {newItem.materialName} with quantity {newItem.quantity} to {promptText}'s recipe.");
    }

    public List<Tuple<string, int>> getRecipe() { return recipe; }
    public string getName() { return buyableName; }
}
