using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BeginEventManager : MonoBehaviour
{
    [SerializeField] private MentorManager mentorManager;
    [SerializeField] private TutorialEventManager tutorialEventManager;
    [SerializeField] private ChangingEventManager changingEventManager;

    public bool skipBegin;

    public bool beginEvent1Invoked;
    public UnityEvent beginEvent1;


    public void Awake()
    {
        beginEvent1.AddListener(() => beginEvent1Invoked = true);
    }

    // Start is called before the first frame update
    void Start()
    {
        if(skipBegin && tutorialEventManager.skipTutotial)
        {
            changingEventManager.ChangeEvent1.Invoke();
        }
        else if(skipBegin && tutorialEventManager.skipTutotial == false)
        {
            tutorialEventManager.tutorialEvent1.Invoke();
        }
        else
        {
            beginEvent1.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(mentorManager.mentorPickedUp == true)
        {
            tutorialEventManager.tutorialEvent1.Invoke();
        }
    }
}
