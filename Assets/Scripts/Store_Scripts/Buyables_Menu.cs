using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buyables_Menu : MonoBehaviour
{
    private GameObject buyableMenu;
    private bool canUnlockItem;

    private Store_Buyables currStoreBuyable;

    // only called once
    void Start()
    {
        buyableMenu = Menu_Manager.instance.buyablesMenu;
        buyableMenu.SetActive(false);
        canUnlockItem = false;
    }

    void Update()
    {

    }

    public void Pause()
    {
        Menu_Manager.instance.openMenu(buyableMenu);
    }

    public void Resume()
    {
        Menu_Manager.instance.closeMenu(buyableMenu);
    }


    public void setCanUnlock(List<Tuple<string, int>> recipe) // called in Store Buyables
    {
        // if can unlock, set the button to white
        // then, if clicked, 
        canUnlockItem = true;
        foreach (var item in recipe) 
        {
            int quantInvItem = Inventory.inventory.materials[item.Item1];
            if(quantInvItem < item.Item2)
            {
                canUnlockItem = false;
            }
        }
        
    }

    public void setMenuInfo(string name, bool isUnlocked, string description, Sprite bSprite, List<Tuple<string, int>> recipe)
    {
        GameObject nameField = GameObject.Find("BuyableNameTMP");
        nameField.GetComponent<TMPro.TextMeshProUGUI>().text = name;

        GameObject imgField = GameObject.Find("BuyableImage");
        var img = imgField.GetComponent<UnityEngine.UI.Image>();
        img.sprite = bSprite;
        img.SetNativeSize();
        if (isUnlocked) { img.color = Color.white; }
        else { img.color = Color.black; }

        GameObject titleField = GameObject.Find("PostItTitleTMP");
        var title = titleField.GetComponent<TMPro.TextMeshProUGUI>();
        GameObject textField = GameObject.Find("PostItTextTMP");
        var text = textField.GetComponent<TMPro.TextMeshProUGUI>();
        GameObject unlockButton = GameObject.Find("UnlockButton");

        if (isUnlocked){
            title.text = "Description";
            text.text = description;
            if (unlockButton) { unlockButton.SetActive(false); }
        }
        else {
            title.text = "Recipe";
            string recipeTxt = "";
            foreach (var item in recipe) { recipeTxt += $"{item.Item2} x {item.Item1}\n"; }

            recipeTxt += "\nYou Have:\n";
            foreach (var item in recipe) {
                //var tup = Inventory.inventory.materials[item.Item1]; // gets the (name, tuple associated w the item name
                recipeTxt += $"{Inventory.inventory.materials[item.Item1]} x {item.Item1} \n";
            }
            text.text = recipeTxt;

            // set button stuff
            if (canUnlockItem) 
            {
                Color newColor = unlockButton.GetComponent<Image>().color;
                newColor.a = 1f;  // Set alpha to 1 for full opacity
                unlockButton.GetComponent<Image>().color = newColor;
                unlockButton.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "Unlock!";
            }
            else
            {
                Color newColor = unlockButton.GetComponent<Image>().color;
                newColor.a = 0f;
                unlockButton.GetComponent<Image>().color = newColor;
                unlockButton.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "";

            }
        }
    }

    

    public void Unlock()
    {
        if (canUnlockItem)
        {
            currStoreBuyable.setLock(true);
            foreach (var item in currStoreBuyable.recipe)
            {
                Inventory.inventory.materials[item.Item1] -= item.Item2;
            }

            Resume();
        }
        // set the unlock
        //close menu? (do we need to Resume?)
    }

    public void setCurrBuyable(Store_Buyables buyable) { currStoreBuyable = buyable; }

}
