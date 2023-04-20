using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ChangeTerrein : MonoBehaviour
{
    private EventManager eventManager;
    private RotateScript rotate;
    
    [SerializeField]
    private TerrainManager terrainManager;
    public bool event1Active;
    
    [SerializeField]
    private int amountOfRounds;
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
        switch (terrainManager.quarterIndx)
        {
            //Check what quater is the opposite quater
            case 0:
            case 1:
                ChangeTerrainToOcean(terrainManager.quarterIndx + 2);
                break; 
            case 2:
            case 3:
                ChangeTerrainToOcean(terrainManager.quarterIndx - 2);
                break;
        }
        terrainManager.changedTerrains++;
        terrainManager.quarterIndx++;
    }

    private void ChangeTerrainToOcean(int selectedTerrein)
    {

        if (event1Active == true && terrainManager.changedTerrains <= terrainManager.beachTerrains.Count)
        {
            
            Debug.Log("changedTerrains " + terrainManager.changedTerrains + "beachterrain.count " + terrainManager.beachTerrains.Count);
            Debug.Log("quarterIndx: " + terrainManager.quarterIndx);
            
            //set the location of new terrein
            Vector3 locationNewTerrain;
            locationNewTerrain = terrainManager.forrestTerrains[selectedTerrein].transform.position;
            terrainManager.forrestTerrains[selectedTerrein].SetActive(false);

            //turn on the the new terrain.
            terrainManager.beachTerrains[terrainManager.changedTerrains].SetActive(true);
            terrainManager.beachTerrains[terrainManager.changedTerrains].transform.position = locationNewTerrain;

            //Rotate the terrein to its right position (has to be done like this terrein can't be rotated via the transform)
            rotateTerreinRightDirection();

            //reset changedTerrains
            if (terrainManager.changedTerrains > terrainManager.beachTerrains.Count)
            {
                terrainManager.changedTerrains = 0;
            }
        }
    }

    private void rotateTerreinRightDirection()
    {
        //look for terrain component !!still needs to be saved

        rotate.RotateTerrain(terrainManager.beachTerrains[terrainManager.changedTerrains].GetComponent<Terrain>());
    }
}
