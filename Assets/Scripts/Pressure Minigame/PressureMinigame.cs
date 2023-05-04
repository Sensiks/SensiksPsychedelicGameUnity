using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureMinigame : MonoBehaviour
{
    public bool minigameActive;

    [Header("Fire Bar Objects")]
    [SerializeField]
    private Transform topPivot;
    [SerializeField]
    private Transform bottemPivot;
    [SerializeField]private GameObject goalObject;
    [SerializeField]private GameObject fireObject;


    [Header("Goal settings")]
    [SerializeField] private Transform goal;
    private float goalPosition, cursurGoal, goalTimer;
    [SerializeField] private float goalTimerMultiplier = 3f;
    private float goalSpeed;
    [SerializeField] private float smoothMotion = 1f;
    


    [Header("Fire settings")]
    [SerializeField] Transform fire;
    [SerializeField] private float firePosition;
    [SerializeField] float fireSize;
    [SerializeField] float firePower = 0.5f;
    [SerializeField] private float firePullVelocity;
    [SerializeField] private float fireInscreasePower = 0.0001f;
    [SerializeField] private float fireNaturalDecreasePower = 0.00003f;
    [SerializeField] private float fireProgressDegradationPower = 0.1f;

    [Header("Progress Bar")]
    private float hookProgress;
    
    //TODO:
    //Resize goal
    //

    public void Update()
    {
        if (minigameActive)
        {
            GoalMover();
            PressureChanger();
        }
        
    }

    public void ActivateMinigame(bool activateMinigame)
    {
        if (activateMinigame)
        {
            goalObject.SetActive(true);
            fireObject.SetActive(true);
            minigameActive = true;

        }
        else if (!activateMinigame)
        {
            goalObject.SetActive(false);
            fireObject.SetActive(false);
            minigameActive = false;
        }
    }

    public void PressureChanger(float increasePower = 0)
    {
        //Manually change pressure (both increase and decrease)
        firePullVelocity += increasePower * Time.deltaTime;

        //Natural Decrease slowly over time
        firePullVelocity -= fireNaturalDecreasePower * Time.deltaTime;

        //Update position of fire
        firePosition += firePullVelocity;
        firePosition = Mathf.Clamp(firePosition, fireSize / 2, 1 - fireSize / 2);
        fire.position = Vector3.Lerp(bottemPivot.position, topPivot.position, firePosition);
    }

    private void GoalMover()
    {
        goalTimer -= Time.deltaTime;
        if (goalTimer <= 0f)
        {
            goalTimer = Random.value * goalTimerMultiplier;

            cursurGoal = Random.value;
        }

        goalPosition = Mathf.SmoothDamp(goalPosition, cursurGoal, ref goalSpeed, smoothMotion);
        goal.position = Vector3.Lerp(bottemPivot.position, topPivot.position, goalPosition);
    }

        
}
