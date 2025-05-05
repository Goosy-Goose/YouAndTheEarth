using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class Data_Persistence_Manager : MonoBehaviour
{
    public static Data_Persistence_Manager instance { get; private set; }

    private Game_Data gameData;
    private List<IData_Persistence> dataPersistenceObjs;


    private void Start()
    {
        this.dataPersistenceObjs = findAllDataPersistenceObjs();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Prevent multiples
        }
    }
    
    private void OnApplicationQuit()
    {
        SaveGame();
    }


    public void NewGame()
    {
        this.gameData = new Game_Data();
    }

    public void LoadGame()
    {
        if (this.gameData == null) { 
            Debug.Log("No Game Data. Loading New Game."); 
            NewGame(); 
        }
        foreach (IData_Persistence dataPersObj in dataPersistenceObjs)
        {
            Debug.Log("trying to load " + dataPersObj);
            dataPersObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        foreach (IData_Persistence dataPersObj in dataPersistenceObjs)
        {
            dataPersObj.SaveData(ref gameData);
        }
    }


    private List<IData_Persistence> findAllDataPersistenceObjs()
    {
        IEnumerable<IData_Persistence> dataPersistenceObjs = 
            Object.FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<IData_Persistence>();

        return new List<IData_Persistence>(dataPersistenceObjs);
    }
}
