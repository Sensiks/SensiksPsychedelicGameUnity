using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensiks.SDK.UnityLibrary;
using Sensiks.SDK.Shared.SensiksDataTypes;

public class FurnaceTrigger : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private FurnaceManager furnaceManager;

    [SerializeField]
    private PressureMinigame pressureMinigame;

    [Header("Settings")]
    [SerializeField]
    private float pressureFromCoal;

    [SerializeField]
    private CoalOnShovel coalOnShovel;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coal")
        {
            Debug.Log("Coal in fire");
            furnaceManager.FireOn();
            pressureMinigame.PressureChanger(pressureFromCoal);
            coalOnShovel.ShovelSwitch(false);
            //SensiksManager.SetHeaterIntensity(HeaterPosition.FRONT, 0.5f);
            //SensiksManager.SetActiveScent(Scent.SMOKE, 0.1f);
            //onPressureChange.Raise(this, 30);
            //Destroy(other);

        }
    }
}
