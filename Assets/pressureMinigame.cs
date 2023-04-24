using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureMinigame : MonoBehaviour
{
    [SerializeField]
    private Transform bottemPivot, topPivot;

    [SerializeField]
    private Transform cursur;

    private float cursurPosition, cursurGoal, cursurTimer;
    [SerializeField]
    private float timerMultiplier = 3f;

    public void Update()
    {
        cursurTimer -= Time.deltaTime;
        if (cursurTimer <= 0f)
        {
            cursurTimer = UnityEngine.Random.value * timerMultiplier;
        }
    }

        
}
