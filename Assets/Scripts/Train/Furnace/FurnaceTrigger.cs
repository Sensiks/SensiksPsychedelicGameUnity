using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensiks.SDK.UnityLibrary;
using Sensiks.SDK.Shared.SensiksDataTypes;

public class FurnaceTrigger : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject coal;
    [SerializeField] private FurnaceManager furnaceManager;
    [SerializeField] private PressureMinigame pressureMinigame;
    [SerializeField] private CoalOnShovel coalOnShovel;

    
    [Header("Settings")]
    [SerializeField] private float pressureFromCoal;


    //if coal touches triggerbox increase pressure and turn off coal, mesh renderer from normal coal otherwise hands are turned off.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coal")
        {

            Debug.Log("Coal in fire");
            furnaceManager.FireOn();
            pressureMinigame.PressureChanger(pressureFromCoal);
            pressureMinigame.coalAmountDeposited++;
            coalOnShovel.ShovelSwitch(false);
            coal.GetComponent<MeshRenderer>().enabled = false;
        }
    }
    public void ChangePressureFromCoal(float newPressureFromCoal)
    {
        pressureFromCoal = newPressureFromCoal;
    }
}
