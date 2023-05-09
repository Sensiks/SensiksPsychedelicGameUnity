using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    //public Transform NextObjectiveMentor;
    //public List<AudioClip> audioClips;

    [Header("StarterEvent")]
    [SerializeField] public UnityEvent starterEvent;
    public bool starteventInvoked;

    [Header("TutorialEvent")]
    [SerializeField] public UnityEvent tutorialEvent1;
    [SerializeField] public bool tutorialEvent1Invoked;

    [SerializeField] public UnityEvent tutorialEvent2;
    [SerializeField] public bool tutorialEvent2Invoked;

    [SerializeField] public UnityEvent tutorialEvent3;
    [SerializeField] public bool tutorialEvent3Invoked;

    [SerializeField] public UnityEvent tutorialEvent4;
    [SerializeField] public bool tutorialEvent4Invoked;

    [Header("Event1")]
    [SerializeField] public UnityEvent event1;
    public bool event1Invoked;

    [Header("Event2")]
    [SerializeField] public UnityEvent event2;
    public bool event2Invoked;


    private void OnEnable()
    {
        
    }
    //private void OnDisable()
    //{
    //    Debug.Log("OnDisable EventManager");
    //    starterEvent.RemoveAllListeners();
    //    event1.RemoveAllListeners();
    //    event2.RemoveAllListeners();
    //}
    //public Event currentEvent = Event.DEFAULT;
    public void Awake()
    {
        starterEvent.AddListener(() => this.starteventInvoked = true);
        event1.AddListener(() => event1Invoked = true);
        event2.AddListener(() => event1Invoked = true);
    }

    public void Start()
    {

        starterEvent.Invoke();
    }
    private void Update()
    {

    }

    private void CheckActiveEvent()
    {

    }
}
