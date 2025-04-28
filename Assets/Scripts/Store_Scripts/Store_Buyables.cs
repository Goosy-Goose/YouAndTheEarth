using UnityEngine;

public class Store_Buyables : Store_Item
{
    [SerializeField] private string buyableName;
    [SerializeField] private string description;
    [SerializeField] private bool isUnlocked;

    private GameObject buyableMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buyableMenu = Menu_Manager.instance.buyablesMenu;
        setLock(false);
    }

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
            // send all the info?
            Sprite buyableSprite = GetComponent<SpriteRenderer>().sprite;
            buyableMenu.GetComponent<Buyables_Menu>().setMenuInfo(buyableName, isUnlocked, description, buyableSprite);
        }

    }

    public void setLock(bool lockStatus)
    {
        isUnlocked = lockStatus;
        // sets the sprite to blacked out or not
        if (isUnlocked) { GetComponent<SpriteRenderer>().color = Color.white; }
        else { GetComponent<SpriteRenderer>().color = Color.black; }
    }
}
