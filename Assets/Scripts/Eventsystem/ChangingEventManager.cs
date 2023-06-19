using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChangingEventManager : MonoBehaviour
{
    [Header("References")]
    public TutorialEventManager tutorialEventManager;


    [Header("Events")]
    [SerializeField] public bool ChangingEvent1Invoked;
    [SerializeField] public UnityEvent ChangeEvent1;

    [SerializeField] public bool ChangingEvent2Invoked;
    [SerializeField] public UnityEvent ChangeEvent2;

    // Start is called before the first frame update
    void Start()
    {
        ChangeEvent1.AddListener(() => ChangingEvent1Invoked = true);
    }

    // Update is called once per frame
    void Update()
    {
        if(ChangingEvent1Invoked == true)
        {

        }   
    }


}
