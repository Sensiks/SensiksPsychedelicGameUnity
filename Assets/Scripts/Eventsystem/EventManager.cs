using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    //public Transform NextObjectiveMentor;
    //public List<AudioClip> audioClips;

    [Header("TutorialEvents")]
    [SerializeField] public bool tutorialEvent1Invoked;
    [SerializeField] public UnityEvent tutorialEvent1;

    [SerializeField] public bool tutorialEvent2Invoked;
    [SerializeField] public UnityEvent tutorialEvent2;

    [SerializeField] public bool tutorialEvent3Invoked;
    [SerializeField] public UnityEvent tutorialEvent3;

    [SerializeField] public bool tutorialEvent4Invoked;
    [SerializeField] public UnityEvent tutorialEvent4;

    [SerializeField] public bool tutorialEvent5Invoked;
    [SerializeField] public UnityEvent tutorialEvent5;

    [Header("After Tutorial Event")]
    [SerializeField] public bool afterTutorialEventInvoked;
    [SerializeField] public UnityEvent afterTutorialEvent;

    [Header("3 Minigame Win Event")]
    [SerializeField] public bool threeWinEventInvoked;
    [SerializeField] public UnityEvent threeWinEvent;

    [Header("References")]
    [SerializeField] private TrainManager trainManager;
    [SerializeField] private PressureMinigame pressureMinigame;
    

    
    public void Awake()
    {
        tutorialEvent1.AddListener(() => tutorialEvent1Invoked = true);
        tutorialEvent2.AddListener(() => tutorialEvent2Invoked = true);
        tutorialEvent3.AddListener(() => tutorialEvent3Invoked = true);
        tutorialEvent4.AddListener(() => tutorialEvent4Invoked = true);
        afterTutorialEvent.AddListener(() => afterTutorialEventInvoked = true);
        threeWinEvent.AddListener(() => threeWinEventInvoked = true);

    }

    public void Start()
    {
        tutorialEvent1.Invoke();
        Debug.Log("tutorialevent1 invoked");
    }

    private void Update()
    {
        if (pressureMinigame.coalAmountDeposited == 1 && tutorialEvent1Invoked)
        {
            Debug.Log("coalAmountDeposted");
            tutorialEvent1Invoked = false;
            tutorialEvent2.Invoke();
            Debug.Log("tutorialevent2 invoked");

        }

        if (pressureMinigame.winAmounts == 1 && tutorialEvent2Invoked)
        {
            
            tutorialEvent2Invoked = false;
            tutorialEvent3.Invoke();
            Debug.Log("tutorialevent3 invoked");

        }

        if (pressureMinigame.progressAmount == 0 && tutorialEvent3Invoked)
        {
            tutorialEvent3Invoked = false;
            tutorialEvent4.Invoke();
            Debug.Log("tutorialevent4 invoked");
        }

        if (pressureMinigame.winAmounts == 2 && tutorialEvent4Invoked)
        {
            tutorialEvent4Invoked = false;
            tutorialEvent5.Invoke();
            Debug.Log("aftertutorialevent invoked");
        }

        if(pressureMinigame.winAmounts == 6 && afterTutorialEventInvoked)
        {
            afterTutorialEventInvoked = false;
            threeWinEvent.Invoke();
            Debug.Log("threewinevent invoked");
        }
    }

    private void CheckActiveEvent()
    {

    }
}
