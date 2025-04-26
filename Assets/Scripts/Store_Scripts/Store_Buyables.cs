using UnityEngine;

public class Store_Buyables : Store_Item
{
    [SerializeField] private string buyableName;
    [SerializeField] private string description;
    [SerializeField] private bool isUnlocked;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        setLock(false);
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void doInteraction()
    {
        base.doInteraction();
        Debug.Log("Child Interaction");
        // open the buyables menu from menu manager? first set all the stuff in it?
        Menu_Manager.instance.buyablesMenu.SetActive(true);

    }

    public void setLock(bool lockStatus)
    {
        isUnlocked = lockStatus;
        // sets the sprite to blacked out or not
        if (isUnlocked) { GetComponent<SpriteRenderer>().color = Color.white; }
        else { GetComponent<SpriteRenderer>().color = Color.black; }
    }
}
