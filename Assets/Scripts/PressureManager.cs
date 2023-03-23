using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sensiks.SDK.Shared.SensiksDataTypes;

public class PressureManager : MonoBehaviour
{
    [SerializeField]
    private float minPressure, maxPressure, currentPressure, pressureDecreasePerSecond;

    [SerializeField]
    private Image mask;

    public void Update()
    {
        GetCurrentFill();
    }

    public void FixedUpdate()
    {
        //currentPressure -= pressureDecreasePerSecond * Time.deltaTime;
        PressureDown(0.02f);
    }

    public void PressureUp(float amount)
    {
        Debug.Log("current pressure: " + amount);
        
        if(currentPressure + amount > maxPressure)
        {
            currentPressure = maxPressure;
        }
        else
        {
            currentPressure += amount;
        }
    }

    public void PressureDown(float amount)
    {
        if(currentPressure - amount < minPressure)
        {
            currentPressure = minPressure;
        }
        else
        {
            currentPressure -= amount;
        }
        

        
    }

    

    void GetCurrentFill()
    {
        float fillAmount = currentPressure / maxPressure;
        mask.fillAmount = fillAmount;
    }
}
