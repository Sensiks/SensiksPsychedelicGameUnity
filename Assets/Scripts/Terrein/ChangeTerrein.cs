using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ChangeTerrein : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private EventManager eventManager;
    [SerializeField] private TerrainManager terrainManager;
    [SerializeField] private RotateScript rotateScript;


    public Terrain terrainToBeRoteted;


    
    public bool event1Active;
    
    [SerializeField]
    private int amountOfRounds;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && terrainManager.changeTerrainActive == true)
        {
            Debug.Log("ChangeTerrain");
            SelectTerrain();
        }
    }

    //Select right terrain tile to be replaced
    private void SelectTerrain()
    {
        terrainToBeRoteted = terrainManager.beachTerrains[terrainManager.changedTerrains].GetComponent<Terrain>();
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

        if (terrainManager.quarterIndx > 3)
        {
            terrainManager.quarterIndx = 0;
        }

    }

    //Replace terrein tile
    private void ChangeTerrainToOcean(int selectedTerrein)
    {

        if (event1Active == true && terrainManager.changedTerrains <= terrainManager.beachTerrains.Count)
        {
            
            //Debug.Log("changedTerrains " + terrainManager.changedTerrains + "beachterrain.count " + terrainManager.beachTerrains.Count);
            //Debug.Log("quarterIndx: " + terrainManager.quarterIndx);
            
            //get the location of new terrain
            Vector3 locationNewTerrain;
            locationNewTerrain = terrainManager.forrestTerrains[selectedTerrein].transform.position;

            //turn off old terrain
            terrainManager.forrestTerrains[selectedTerrein].SetActive(false);

            //turn on the the new terrain.
            terrainManager.beachTerrains[terrainManager.changedTerrains].SetActive(true);

            //set the position of the new terrain.
            terrainManager.beachTerrains[terrainManager.changedTerrains].transform.position = locationNewTerrain;

            //Rotate the terrein to its right position (has to be done like this terrein can't be rotated via the transform)
            //switch (terrainManager.quarterIndx)
            //{
            //    case (0):
            //        //rotateTerreinRightDirection();
            //        //rotateTerreinRightDirection();

            //        break;
            //    case (1):
            //        //rotateTerreinRightDirection();
            //        break;
            //    case (2):
            //        //rotateTerreinRightDirection();
            //        break;
            //    case (3):
            //        //rotateTerreinRightDirection();
            //        break;

            //}

            //reset changedTerrains
            if (terrainManager.changedTerrains > terrainManager.beachTerrains.Count)
            {
                terrainManager.changedTerrains = 0;
            }
        }
    }

    private void rotateTerreinRightDirection()
    {
        //Look for terrain component !!still needs to be saved


        rotateScript.RotateTerrain(terrainToBeRoteted);
    }
}
