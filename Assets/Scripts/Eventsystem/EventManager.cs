using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    //public Transform NextObjectiveMentor;
    //public List<AudioClip> audioClips;

    [Header("Event1")]
    public UnityEvent event1;

    [Header("Event2")]
    public UnityEvent event2;
    
    
    public enum CurrentEvent
    {
        DEFAULT, EVENT1, EVENT2, EVENT3
    }


    //public Event currentEvent = Event.DEFAULT;
    public void Start()
    {
        event1.Invoke();
        
        
    }
    private void Update()
    {

    }

    private void CheckActiveEvent()
    {

    }
}
