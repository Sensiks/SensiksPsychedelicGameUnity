using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sensiks.SDK.Shared.SensiksDataTypes;

public class PressureManager : MonoBehaviour
{
    [Header("Pressure Management")]
    [SerializeField]
    private Image currentPressureMask;
    [SerializeField]
    private float minPressure;
    [SerializeField]
    private float maxPressure;
    [SerializeField]
    private float currentPressure;
    [SerializeField]
    private float pressureDecreasePerSecond;

    [Header("Pressure Goal")]
    [SerializeField]
    private Image goalPressureMask;
    [SerializeField]
    private float goalSize;
    private bool isInGoal;
    private float goalValue;
    private int numberOfGoals;
    public bool goalisActive;



    private void Start()
    {
        SpawnGoal();
    }

    public void FixedUpdate()
    {
        PressureChange(pressureDecreasePerSecond * Time.deltaTime);
        GetCurrentPressureFill();
        if (currentPressure >= goalValue - goalSize && currentPressure <= goalValue + goalSize)
        {
            PressureInGoal();
        }
    }

    //Manage the current pressure
    public void PressureChange(float amount)
    {
        if (currentPressure + amount > maxPressure)
        {
            currentPressure = maxPressure;
        }
        else if (currentPressure - amount < minPressure)
        {
            currentPressure = minPressure;
        }
        else
        {
            currentPressure += amount;
        } 
    }

    //Spawn a pressure goal
    private void SpawnGoal()
    {
        if (goalisActive == true)
        {
            //goalPressureMask.transform.position.x = goalValue / 100;
        }
        goalValue = 30;
        
        //goalValue = Random.Range(minPressure + goalSize/2, maxPressure - goalSize/2);
    }

    private void PressureInGoal()
    {
        numberOfGoals++;

    }

    void GetCurrentPressureFill()
    {
        float fillAmount = currentPressure / maxPressure;
        currentPressureMask.fillAmount = fillAmount;
    }

    void GetGoalPressureFill()
    {
        
    }
}
