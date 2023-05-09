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
    
    public void Awake()
    {
        tutorialEvent1.AddListener(() => tutorialEvent1Invoked = true);
        tutorialEvent2.AddListener(() => tutorialEvent2Invoked = true);
        tutorialEvent3.AddListener(() => tutorialEvent3Invoked = true);
        tutorialEvent4.AddListener(() => tutorialEvent4Invoked = true);
    }

    public void Start()
    {
        tutorialEvent1.Invoke();
    }
    private void Update()
    {

    }

    private void CheckActiveEvent()
    {

    }
}
