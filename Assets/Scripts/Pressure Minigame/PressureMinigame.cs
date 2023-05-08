using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private float goalSize;
    


    [Header("Fire settings")]
    [SerializeField] Transform fire;
    [SerializeField] private float firePosition;
    [SerializeField] float fireSize;
    
    [SerializeField] private float firePullVelocity;
    [SerializeField] private float fireInscreasePower = 0.0001f;
    [SerializeField] private float fireNaturalDecreasePower = 0.00003f;
    [SerializeField] private float fireProgressDegradationPower = 0.1f;

    [Header("Progress Bar")]
    [SerializeField] Transform progressBarTransform;
    private float progressAmount;
    [SerializeField] float progressBarIncrease;
    [SerializeField] float progressBarDegredasion;
    
    //TODO:
    //Resize goal, be able to win
    //

    public void Start()
    {
        //ResizeGoal();
    }

    public void Update()
    {

        //Make stateMachine here
        if (minigameActive)
        {
            GoalMover();
            PressureChanger();
            ProgressCheck();
        }

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

        Debug.Log("min: " + min + "max: " + max);
        if (min < firePosition && firePosition < max)
        {
            Debug.Log("Increase");
            progressAmount += progressBarIncrease * Time.deltaTime;
        }
        else
        {
            Debug.Log("Decrease");
            progressAmount -= progressBarDegredasion * Time.deltaTime;
        }

        Mathf.Clamp(progressAmount, 0.0f, 1.0f);

        if(progressAmount >= 1)
        {
            //Win
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



    public void ActivateMinigame(bool activateMinigame)
    {
        if (activateMinigame)
        {
            goalObject.GetComponent<Image>().CrossFadeAlpha(255, 0.1f, true);
            fireObject.GetComponent<Image>().CrossFadeAlpha(255, 0.1f, true);
            minigameActive = true;

        }
        else if (!activateMinigame)
        {
            goalObject.GetComponent<Image>().CrossFadeAlpha(0, 0.1f, true);
            fireObject.GetComponent<Image>().CrossFadeAlpha(0, 0.1f, true); ;
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
        RectTransform rt = (RectTransform)goalObject.transform;
        float currentWidth = rt.rect.width;

        goalTimer -= Time.deltaTime;
        if (goalTimer <= 0f)
        {
            goalTimer = Random.value * goalTimerMultiplier;

            cursurGoal = Random.value;
        }

        goalPosition = Mathf.Clamp(goalPosition, currentWidth / 2, 1 - currentWidth / 2);
        goalPosition = Mathf.SmoothDamp(goalPosition, cursurGoal, ref goalSpeed, smoothMotion);
        goal.position = Vector3.Lerp(bottemPivot.position, topPivot.position, goalPosition);
    }

        
}
