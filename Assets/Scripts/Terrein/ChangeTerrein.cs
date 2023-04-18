using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTerrein : MonoBehaviour
{
    private MeshRenderer myMeshrenderer;
    public CurrentQuarter currentQuarter;
    private EventManager eventManager;
    public bool event1Active;
    
    [SerializeField]
    private int quaterIndx;
    private int amountOfRounds;
    private int oppositequarterindx = 2;
    private int changedTerrains;

    [SerializeField]
    private List<Terrain> forrestTerrains;
    [SerializeField]
    private List<Terrain> beachTerrains;

    public enum CurrentQuarter
    {
        FIRSTQUARTER, SECONDQUATER, THIRTQUARTER, FOURTHQUARTER
    }

    private void Start()
    {
        myMeshrenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Debug.Log("ChangeTerrain");
            quaterIndx++;
            SwitchCurrentQuarter();
            ChangeTerrainToOcean();
        }
    }

    private void ChangeTerrainToOcean()
    {
        if(event1Active == true)
        {
            Vector3 locationNewTerrain;
            locationNewTerrain = forrestTerrains[quaterIndx + oppositequarterindx + 1].GetPosition();
            forrestTerrains[quaterIndx + oppositequarterindx + 1].enabled = false;
            
            beachTerrains[changedTerrains].enabled = true;
            beachTerrains[changedTerrains].transform.position = locationNewTerrain;
            changedTerrains++;

            if (changedTerrains >= beachTerrains.Count)
            {
                changedTerrains = 0;
            }
        }
    }

    private void SwitchCurrentQuarter()
    {
         switch (quaterIndx)
            {
                case (1):
                    currentQuarter = CurrentQuarter.FIRSTQUARTER;
                    break;
                case (2):
                    currentQuarter = CurrentQuarter.SECONDQUATER;
                    break;
                case (3):
                    currentQuarter = CurrentQuarter.THIRTQUARTER;
                    break;
                case (4):
                    quaterIndx = 0;
                    amountOfRounds++;
                    currentQuarter = CurrentQuarter.FOURTHQUARTER;
                    break;

            }
    }



}
