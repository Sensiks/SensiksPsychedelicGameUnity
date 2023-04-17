using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTerrein : MonoBehaviour
{
    private MeshRenderer myMeshrenderer;
    public CurrentQuarter currentQuarter;

    private EventManager eventManager;
    private int amountOfQuaters;
    private int amountOfRounds;
    public enum CurrentQuarter
    {
        FIRSTQUARTER, SECONDQUATER, THIRTQUARTER, FOURTHQUARTER;
    }

    private void Start()
    {
        myMeshrenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Train"))
        {
            
            amountOfQuaters++;
            UpdateCurrentQuarter();
           
        }
    }

    private void ChangeTerreinQuarter()
    {
        if (eventManager.Event1 != null && eventManager.Event1.GetPersistentEventCount() > 0)
        {

        }
    }

    private void UpdateCurrentQuarter()
    {
         switch (amountOfQuaters)
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
                    amountOfQuaters = 0;
                    currentQuarter = CurrentQuarter.FOURTHQUARTER;
                    break;

            }
    }



}
