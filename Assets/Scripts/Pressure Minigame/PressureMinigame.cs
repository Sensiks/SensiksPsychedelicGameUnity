using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class PressureMinigame : MonoBehaviour
{
    [Header("stuff to keep track of")]
    public bool minigameActive;
    [SerializeField] public int winAmounts;
    [SerializeField] public int coalAmountDeposited;

    [Header("References")]
    [SerializeField] private TutorialEventManager eventManager;
    [SerializeField] private TrainManager trainManager;

    [Header("Pressure Bar Objects")]
    [SerializeField]
    private Transform topPivot;
    [SerializeField]
    private Transform bottemPivot;
    [SerializeField] private GameObject goalObject;
    [SerializeField] private GameObject fireObject;
    


    [Header("Goal settings")]
    [SerializeField] private Transform goal;
    private float goalPosition, nextGoalDestination, goalTimer;
    [SerializeField] private float goalTimerMultiplier = 3f;
    private float goalSpeed;
    [SerializeField] private float smoothMotion = 1f;
    [SerializeField] private float goalSize;

    [Header("Fire settings")]
    [SerializeField] Transform fire;
    [SerializeField] private float firePosition;
    [SerializeField] float fireSize;
    
    [SerializeField] private float firePullVelocity;
    [SerializeField] private float fireInscreaseDegredation;
    [SerializeField] private float fireMultiplication;
    [SerializeField] private float fireDecreasePower = 0.00003f;
    [SerializeField] private float maxDecreaseVeloticy = -0.0008f;

    [Header("Progress Bar")]
    [SerializeField] Transform progressBarTransform;
    public float progressAmount;
    [SerializeField] float progressBarIncrease;
    [SerializeField] float progressBarDegredasion;


    [Header("StateMachine")]
    public MinigameState miniGameState;
    private MinigameState lastMiniGameState;
    public enum MinigameState
        {DEFAULT = 0, ON = 1, OFF = 2, TUTORIAL = 3}

    public void FixedUpdate()
    {
        UpdateGameState();

    }

    /// <summary>
    /// Updates and triggers the minigame state;
    /// 0 == DEFAULT
    /// 1 == ON
    /// 2 == OFF
    /// 3 == TUTORIAL
    /// </summary>
    /// <param name="newState">int for what the new gamestate should be</param>
    public void UpdateGameState(int newState = 0)
    {
        if (newState == 0)
        {
            newState = (int)lastMiniGameState;
        }
        else
            miniGameState = (MinigameState)newState;


        
        switch ((MinigameState)newState)
        {
            case MinigameState.DEFAULT:
                //Debug.Log("DEFAULT state ");
                break;

            case MinigameState.ON:
                ActivateMinigame(true);
                PressureChanger();
                ProgressCheck();
                GoalMover();
                lastMiniGameState = MinigameState.ON;
                //Debug.Log("ON state");
                break;

            case MinigameState.OFF:
                ActivateMinigame(false);
                lastMiniGameState = MinigameState.OFF;
                Debug.Log("OFF state");
                break;

            case MinigameState.TUTORIAL:
                ActivateMinigame(true);
                ProgressCheck();
                PressureChanger();
                GoalMover();
                lastMiniGameState = MinigameState.TUTORIAL;
                //Debug.Log("TUTORIAL state");
                break;
        }
    }

    //size is between 0 and 1, so 0.5 is half of the bar, 
    public void ResizeGoal(float newWidth)
    {
        RectTransform rt = (RectTransform)goalObject.transform;
        float currentWidth = rt.rect.width;
        float currentHeight = rt.rect.height;
        if(newWidth == null)
        {
            newWidth = currentWidth;
        }
        //Debug.Log("currentWidth: " + currentWidth + "currentHeight: " + currentHeight);
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, currentHeight);
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newWidth);
        goalSize = newWidth;
    }

    public void PressureChanger(float increasePower = 0)
    {
        
        //Manually change pressure (both increase and decrease)
        if (increasePower == 0)
        {
            //Nothing happens
        }
        else
        {
            firePullVelocity += increasePower * Time.deltaTime;
        }

        if (firePullVelocity > 0)
        {
            firePullVelocity -= fireInscreaseDegredation * Time.deltaTime;
            
        }

        if (trainManager.leverActive == true)
        {
            firePullVelocity -= fireDecreasePower * Time.deltaTime;
            if (firePullVelocity <= maxDecreaseVeloticy)
            {
                firePullVelocity = maxDecreaseVeloticy;
            }
        }
        else if (firePullVelocity < 0 && trainManager.leverActive == false)
        {

            firePullVelocity += fireInscreaseDegredation * Time.deltaTime;
            

        }
        

        //check if the position is at the beginning or end of the bar, if so set velocity to 0;
        if (firePosition >= 0.94f && firePullVelocity >= 0f)
        {
            firePullVelocity = 0f;
        }
        else if (firePosition <= 0.06f && firePullVelocity <= 0.0f)
        {
            
            firePullVelocity = 0f;
        }

        //Update position of fire
        firePosition += firePullVelocity;
        firePosition = Mathf.Clamp(firePosition, fireSize / 2, 1 - fireSize / 2);
        fire.position = Vector3.Lerp(bottemPivot.position, topPivot.position, firePosition);
    }

    private void GoalMover()
    {
        RectTransform rt = (RectTransform)goalObject.transform;
        float currentWidth = rt.rect.width;

        if (miniGameState == MinigameState.ON)
        {
            goalTimer -= Time.deltaTime;
            if (goalTimer <= 0f)
            {
                goalTimer = Random.value * goalTimerMultiplier;

                nextGoalDestination = Random.value;
            }
            goalPosition = Mathf.SmoothDamp(goalPosition, nextGoalDestination, ref goalSpeed, smoothMotion);
        }

        goalPosition = Mathf.Clamp(goalPosition, currentWidth / 2, 1 - currentWidth / 2);
        goal.position = Vector3.Lerp(bottemPivot.position, topPivot.position, goalPosition);
    }

    public void ProgressCheck()
    {
        RectTransform rt = (RectTransform)goalObject.transform;
        float currentWidth = rt.rect.width;


        Vector3 ls = progressBarTransform.localScale;
        ls.x = progressAmount;
        progressBarTransform.localScale = ls;

        float min = goalPosition - currentWidth / 2;
        float max = goalPosition + currentWidth / 2;

        //Debug.Log("min: " + min + "max: " + max);
        if (min < firePosition && firePosition < max)
        {
            //Debug.Log("Increase");
            progressAmount += progressBarIncrease * Time.deltaTime;
        }
        else
        {
            //Debug.Log("Decrease");
            progressAmount -= progressBarDegredasion * Time.deltaTime;
        }

        progressAmount = Mathf.Clamp(progressAmount, 0.0f, 1.0f);

        if (progressAmount >= 1)
        {
            Win();
        }

        //events
        
    }

    public void SetFireLocation(float Location)
    {
        firePosition = Location;
    }

    public void ActivateMinigame(bool activateMinigame)
    {
        goalObject.GetComponent<Image>().enabled = activateMinigame;
        fireObject.GetComponent<Image>().enabled = activateMinigame;
        minigameActive = activateMinigame;
    }

    public void SetGoalLocation(float newGoalPosition)
    {
        RectTransform rt = (RectTransform)goalObject.transform;
        float currentWidth = rt.rect.width;
        goalPosition = Mathf.Clamp(newGoalPosition, currentWidth / 2, 1 - currentWidth / 2);
        goalPosition = Mathf.SmoothDamp(goalPosition, nextGoalDestination, ref goalSpeed, smoothMotion);
        goal.position = Vector3.Lerp(bottemPivot.position, topPivot.position, goalPosition);
    }

    //if progressbar is full Win.
    public void Win()
    {
        //firePosition = 0;
        winAmounts++;
        progressAmount = 0.0f;
    }



        
}
