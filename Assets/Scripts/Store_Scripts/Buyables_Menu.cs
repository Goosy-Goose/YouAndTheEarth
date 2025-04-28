using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buyables_Menu : MonoBehaviour
{
    private GameObject buyableMenu;

    // only called once
    void Start()
    {
        buyableMenu = Menu_Manager.instance.buyablesMenu;
        buyableMenu.SetActive(false);
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

    public void setMenuInfo(string name, bool isUnlocked, string description, Sprite bSprite)
    {
        GameObject nameField = GameObject.Find("BuyableNameTMP");
        nameField.GetComponent<TMPro.TextMeshProUGUI>().text = name;

        GameObject imgField = GameObject.Find("BuyableImage");
        imgField.GetComponent<UnityEngine.UI.Image>().sprite = bSprite;


        GameObject titleField = GameObject.Find("PostItTitleTMP");
        GameObject textField = GameObject.Find("PostItTextTMP");
        GameObject unlockButton = GameObject.Find("UnlockButton");

        if (isUnlocked){ 
            titleField.GetComponent<TMPro.TextMeshProUGUI>().text = "Description";
            textField.GetComponent<TMPro.TextMeshProUGUI>().text = description;
            if (unlockButton) { unlockButton.SetActive(false); }
        }
        else { 
            titleField.GetComponent<TMPro.TextMeshProUGUI>().text = "Recipe"; 
        }
    }

    public void Unlock()
    {

    }
}
