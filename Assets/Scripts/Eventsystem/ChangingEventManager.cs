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
    [SerializeField] public bool ChangingEvent1Invoked;
    [SerializeField] public UnityEvent ChangeEvent1;

    [SerializeField] public bool ChangingEvent2Invoked;
    [SerializeField] public UnityEvent ChangeEvent2;

    [SerializeField] public bool changingEvent3Invoked;
    [SerializeField] public UnityEvent ChangeEvent3;

    // Start is called before the first frame update
    void Awake()
    {
        ChangeEvent1.AddListener(() => ChangingEvent1Invoked = true);
        ChangeEvent2.AddListener(() => ChangingEvent2Invoked = true);
        ChangeEvent3.AddListener(() => changingEvent3Invoked = true);
    }



    // Update is called once per frame
    void Update()
    {
        if(ChangingEvent1Invoked == true && changingWhenInvisible.shovelChangedAndSeen == true)
        {
            ChangingEvent1Invoked = false;
            ChangeEvent2.Invoke();
            Debug.Log("ChangeEvent 2 Invoked");
        }   

        if(ChangingEvent2Invoked == true && treeTwig.twigTouchedCoal)
        {
            ChangingEvent2Invoked = false;
            ChangeEvent3.Invoke();
            Debug.Log("ChangeEvent 3 Invoked");
        }
    }


}
