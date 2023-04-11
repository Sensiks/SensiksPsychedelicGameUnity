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

    [Header("Events")]
    public GameEvent onPressureChange;

    public void Update()
    {
        GetCurrentFill();
    }

    public void FixedUpdate()
    {
        //currentPressure -= pressureDecreasePerSecond * Time.deltaTime;
        PressureChange(-0.02f);
    }

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
        onPressureChange.Raise(this, currentPressure);
    }
    void GetCurrentFill()
    {
        float fillAmount = currentPressure / maxPressure;
        mask.fillAmount = fillAmount;
    }
}
