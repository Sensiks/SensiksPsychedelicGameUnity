using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    //public Transform NextObjectiveMentor;
    //public List<AudioClip> audioClips;

    [Header("TutorialEvent")]
    [SerializeField] public bool tutorialEvent1Invoked;
    [SerializeField] public UnityEvent tutorialEvent1;

    [SerializeField] public bool tutorialEvent2Invoked;
    [SerializeField] public UnityEvent tutorialEvent2;

    [SerializeField] public bool tutorialEvent3Invoked;
    [SerializeField] public UnityEvent tutorialEvent3;

    [SerializeField] public bool tutorialEvent4Invoked;
    [SerializeField] public UnityEvent tutorialEvent4;

    [Header("")]
    [SerializeField] public bool afterTutorialEventInvoked;
    [SerializeField] public UnityEvent afterTutorialEvent;

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
    }

    public void Start()
    {
        tutorialEvent1.Invoke();
    }
    private void Update()
    {
        if (pressureMinigame.coalAmountDeposited == 1 && !tutorialEvent2Invoked)
        {
            Debug.Log("coalAmountDeposted");
            tutorialEvent1Invoked = false;
            tutorialEvent2.Invoke();
            
        }

        if (pressureMinigame.winAmounts == 1 && !tutorialEvent3Invoked)
        {
            tutorialEvent2Invoked = false;
            tutorialEvent3.Invoke();
        }

        if (pressureMinigame.progressAmount > 0 && tutorialEvent3Invoked)
        {
            tutorialEvent3Invoked = false;
            tutorialEvent4.Invoke();
        }

        if (pressureMinigame.winAmounts == 2 && !afterTutorialEventInvoked)
        {
            tutorialEvent4Invoked = false;
            afterTutorialEvent.Invoke();
        }
    }

    private void CheckActiveEvent()
    {

    }
}
