using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Material_Spawn : MonoBehaviour
{

    [SerializeField] private List<GameObject> spawnPoints;
    [SerializeField] private List<Sprite> sprites;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pickSpawnPoints();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void pickSpawnPoints()
    {
        int numSpawns = Random.Range(spawnPoints.Count/5, spawnPoints.Count/2);
        
        // Shuffle the spawn points
        for (int i = spawnPoints.Count; i > 1; i--)
        {
            int j = Random.Range(0,i);
            var t = spawnPoints[j];
            spawnPoints[j] = spawnPoints[i - 1];
            spawnPoints[i - 1] = t;
        }
        
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            if (i <= numSpawns) 
            {
                int matInd = Random.Range(0,sprites.Count);
                string matName = sprites[matInd].name;
                matName = matName.Substring(0, matName.Length - 2);
                matName = char.ToUpper(matName[0]) + matName.Substring(1);
                spawnPoints[i].GetComponent<Material_Item>().materialName = matName;
                spawnPoints[i].GetComponent<SpriteRenderer>().sprite = sprites[matInd];

            }
            else
            {
                spawnPoints[i].SetActive(false);
            }
        }
    }
}
