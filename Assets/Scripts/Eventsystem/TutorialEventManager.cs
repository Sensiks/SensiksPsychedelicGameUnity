using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialEventManager : MonoBehaviour
{
    //public Transform NextObjectiveMentor;
    //public List<AudioClip> audioClips;

    public bool skipTutotial;

    [Header("TutorialEvents")]
    [SerializeField] public bool tutorialEvent1Invoked;
    [SerializeField] public UnityEvent tutorialEvent1;

    [SerializeField] public bool tutorialEvent2Invoked;
    [SerializeField] public UnityEvent tutorialEvent2;

    [SerializeField] public bool tutorialEvent3Invoked;
    [SerializeField] public UnityEvent tutorialEvent3;

    [SerializeField] public bool tutorialEvent4Invoked;
    [SerializeField] public UnityEvent tutorialEvent4;

    [Header("3 Minigame Win Event")]
    [SerializeField] public bool activateChangingEventInvoked;
    [SerializeField] public UnityEvent activateChangingEvent;

    [Header("References")]
    [SerializeField] private TrainManager trainManager;
    [SerializeField] private PressureMinigame pressureMinigame;
    [SerializeField] private ChangingEventManager changingEventManager;
    

    
    public void Awake()
    {
        tutorialEvent1.AddListener(() => tutorialEvent1Invoked = true);
        tutorialEvent2.AddListener(() => tutorialEvent2Invoked = true);
        tutorialEvent3.AddListener(() => tutorialEvent3Invoked = true);
        tutorialEvent4.AddListener(() => tutorialEvent4Invoked = true);
        activateChangingEvent.AddListener(() => activateChangingEventInvoked = true);

    }

    public void Start()
    {
      
        
    }

    private void Update()
    {             
            if (pressureMinigame.winAmounts == 1 && tutorialEvent1Invoked)
            {
                Debug.Log("coalAmountDeposted");
                tutorialEvent1Invoked = false;
                tutorialEvent2.Invoke();
                Debug.Log("tutorialevent2 invoked");
            }

            if (pressureMinigame.progressAmount > 0.01f && tutorialEvent2Invoked)
            {
                tutorialEvent2Invoked = false;
                tutorialEvent3.Invoke();
                Debug.Log("tutorialevent3 invoked");
            }

            if (pressureMinigame.winAmounts == 2 && tutorialEvent3Invoked)
            {
                tutorialEvent3Invoked = false;
                tutorialEvent4.Invoke();
                Debug.Log("tutorialevent4 invoked");
            }

            if (pressureMinigame.winAmounts == 5 && tutorialEvent4Invoked)
            {
                tutorialEvent4Invoked = false;
                changingEventManager.ChangeEvent1.Invoke();
                Debug.Log("threewinevent invoked");
            }
        
    }
}
