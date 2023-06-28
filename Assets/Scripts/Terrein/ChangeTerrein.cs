using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ChangeTerrein : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TerrainManager terrainManager;
    [SerializeField] private int amountOfRounds;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("other transform tag" + other.transform.tag);
        if (other.transform.tag == "Player")
        {
            if(terrainManager.changeTerrainActive == true)
            {
                
                Debug.Log("ChangeTerrain");
                SelectTerrain();
            }

            terrainManager.changedTerrains++;
            terrainManager.quarterIndx++;

            if (terrainManager.quarterIndx > 3)
            {
                terrainManager.quarterIndx = 0;
            }
        }

        
    }

    //Select right terrain tile to be replaced
    private void SelectTerrain()
    {
        switch (terrainManager.quarterIndx)
        {
            //Check what quater is the opposite quater
            case 0:
                ChangeTerrainToForrest(2);
                break;
            case 1:
                ChangeTerrainToForrest(3);
                break; 
            case 2:
                ChangeTerrainToForrest(0);
                break;
            case 3:
                ChangeTerrainToForrest(1);
                break;
        }
        

        

    }

    //Replace terrein tile
    private void ChangeTerrainToForrest(int selectedTerrein)
    {
        Debug.Log("selectedTerrein: " + selectedTerrein);
        if (terrainManager.changedTerrains <= terrainManager.forrestTerrains.Count)
        {
            //turn off old terrain
            terrainManager.swampTerrains[selectedTerrein].SetActive(false);

            //turn on the the new terrain.
            terrainManager.forrestTerrains[selectedTerrein].SetActive(true);

            //reset changedTerrains
            if (terrainManager.changedTerrains > terrainManager.swampTerrains.Count)
            {
                terrainManager.changedTerrains = 0;
            }
        }
    }
}
