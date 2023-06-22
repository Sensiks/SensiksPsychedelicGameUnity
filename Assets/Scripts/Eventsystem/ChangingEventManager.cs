using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChangingEventManager : MonoBehaviour
{
    [Header("References")]
    public TutorialEventManager tutorialEventManager;
    [SerializeField]private ChangingWhenInvisible changingWhenInvisible;
    [SerializeField] private Treetwig treeTwig;


    [Header("Events")]
    [SerializeField] public bool changingEvent1Invoked;
    [SerializeField] public UnityEvent ChangeEvent1;

    [SerializeField] public bool changingEvent2Invoked;
    [SerializeField] public UnityEvent ChangeEvent2;

    [SerializeField] public bool changingEvent3Invoked;
    [SerializeField] public UnityEvent ChangeEvent3;

    [SerializeField] public bool changingEvent4Invoked;
    [SerializeField] public UnityEvent ChangeEvent4;

    [SerializeField] public bool changingEvent5Invoked;
    [SerializeField] public UnityEvent ChangeEvent5;

    [SerializeField] public bool changingEvent6Invoked;
    [SerializeField] public UnityEvent ChangeEvent6;

    // Start is called before the first frame update
    void Awake()
    {
        ChangeEvent1.AddListener(() => changingEvent1Invoked = true);
        ChangeEvent2.AddListener(() => changingEvent2Invoked = true);
        ChangeEvent3.AddListener(() => changingEvent3Invoked = true);
        ChangeEvent4.AddListener(() => changingEvent4Invoked = true);
        ChangeEvent5.AddListener(() => changingEvent5Invoked = true);
        ChangeEvent6.AddListener(() => changingEvent6Invoked = true);
    }



    // Update is called once per frame
    void Update()
    {
        if(changingEvent1Invoked == true && changingWhenInvisible.shovelChangedAndSeen == true)
        {
            changingEvent1Invoked = false;
            ChangeEvent2.Invoke();
            Debug.Log("ChangeEvent 2 Invoked");
        }   

        if(changingEvent2Invoked == true && treeTwig.twigTouchedCoal)
        {
            changingEvent2Invoked = false;
            ChangeEvent3.Invoke();
            Debug.Log("ChangeEvent 3 Invoked");
        }
        
        if(changingEvent3Invoked == true)
        {

        }
    }


}
