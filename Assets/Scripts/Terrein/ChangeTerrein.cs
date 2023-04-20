using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTerrein : MonoBehaviour
{
    private EventManager eventManager;
    
    [SerializeField]
    private TerrainManager terrainManager;
    public bool event1Active;
    
    [SerializeField]
    private int quarterIndx, amountOfRounds, changedTerrains;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Debug.Log("ChangeTerrain");
            SelectTerrain();
        }
    }

    private void SelectTerrain()
    {
        switch (quarterIndx)
        {
            //Check what quater is the opposite quater
            case 0:
            case 1:
                ChangeTerrainToOcean(quarterIndx +2);
                break; 
            case 2:
            case 3:
                ChangeTerrainToOcean(quarterIndx -2);
                break;
        }
    }

    private void ChangeTerrainToOcean(int selectedTerrein)
    {

        if (event1Active == true && changedTerrains <= terrainManager.beachTerrains.Count)
        {
            changedTerrains++;
            quarterIndx++;
            Debug.Log("changedTerrains " + changedTerrains + "beachterrain.count " + terrainManager.beachTerrains.Count);
            Debug.Log("quarterIndx: " + quarterIndx);
            //set the location of new terrein
            Vector3 locationNewTerrain;
            locationNewTerrain = terrainManager.forrestTerrains[selectedTerrein].transform.position;
            terrainManager.forrestTerrains[selectedTerrein].SetActive(false);

            //turn on the the new terrain.
            terrainManager.beachTerrains[changedTerrains].SetActive(true);
            terrainManager.beachTerrains[changedTerrains].transform.position = locationNewTerrain;

            //reset changedTerrains
            if (changedTerrains > terrainManager.beachTerrains.Count)
            {
                changedTerrains = 0;
            }
        }
    }
}
