using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Store_Manager : MonoBehaviour
{
    public static Store_Manager instance;
    public GameObject playerObj;
    public PlayerInput playerInput;
    public List<GameObject> storeItems;

    private Dictionary<string, List<Tuple<string, int>>> recipeBook;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {   
        playerInput = playerObj.GetComponent<PlayerInput>();
        playerInput.SwitchCurrentActionMap(playerInput.defaultActionMap);

        makeRecipeBook();

        //foreach (var kvp in recipeBook)
        //{
        //    Debug.Log($"Key: {kvp.Key}");
        //    foreach (var tuple in kvp.Value)
        //    {
        //        Debug.Log($"  Item1: {tuple.Item1}, Item2: {tuple.Item2}");
        //    }
        //}

        setBuyableRecipes();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Prevent multiple Store_Managers
        }
    }


    // Update is called once per frame
    private void Update()
    {
        
    }

    private void setBuyableRecipes()
    {
        foreach (GameObject item in storeItems)
        {
            var itemComponent = item.GetComponent<Store_Buyables>();

            string itemName = itemComponent.getPromptText();
            foreach (var tup in recipeBook[itemName])
            {
                //Debug.Log("Adding " + tup + " to " + itemName);
                itemComponent.addRecipeItem(tup);
            }

        }
    }

    private void setBuyableLocks()
    {
        // if new game: all storeitem isunlocked set to false
        // else: load from json
    }

    // super scuffed manual adding recipes
    private void makeRecipeBook()
    {
        recipeBook = new Dictionary<string, List<Tuple<string, int>>>
        {
            { "Backpack", new List<Tuple<string, int>> {
                new Tuple<string, int>("Fabric", 4),
                new Tuple<string, int>("Metal", 1)
            }},
            { "Compost", new List<Tuple<string, int>> {
                new Tuple<string, int>("Cardboard", 1),
                new Tuple<string, int>("Leaves", 1),
                new Tuple<string, int>("Paper", 1)
            }},
            { "Phone Case", new List<Tuple<string, int>> {
                new Tuple<string, int>("Plastic", 3),
                new Tuple<string, int>("Leaves", 1)
            }},
            { "Journal", new List<Tuple<string, int>> {
                new Tuple<string, int>("Cardboard", 1),
                new Tuple<string, int>("Paper", 1)
            }},
            { "Birdhouse", new List<Tuple<string, int>> {
                new Tuple<string, int>("Glass", 1),
                new Tuple<string, int>("Leaves", 3),
                new Tuple<string, int>("Wood", 3)
            }},
            { "Cat Litter", new List<Tuple<string, int>> {
                new Tuple<string, int>("Fabric", 2),
                new Tuple<string, int>("Paper", 2),
                new Tuple<string, int>("Wood", 2)
            }}
        };


    }
}
