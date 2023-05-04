using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MentorDialogueSystem : MonoBehaviour
{
    public AudioSource mentorAudioSource;

    private int audioIndex = 0;
    public EventManager eventManager;
    
    public List<AudioClip> currentAudioClips;

    [Header("StarterEvent Audioclips")]
    public List<AudioClip> startEventAudioclips;

    [Header("Event 1 Audioclips")]
    public List<AudioClip> event1Audioclips;

    [Header("Event 2 Audioclips")]
    public List<AudioClip> event2Audioclips;

    //step 1: Listen to for an event
    private void Start()
    {
        //mentorAudioSource = GetComponent<AudioSource>();
        eventManager.starterEvent.AddListener(NewAudioClipList);
    }
    
    //step 2: Choose a new list to listen to
    private void NewAudioClipList()
    {
        Debug.Log("in new audiocliplist");
        Debug.Log(eventManager.starteventInvoked);
        if (eventManager.starteventInvoked == true)
        {
            Debug.Log("new audio clip list start event");
            Debug.Log(startEventAudioclips);
            UpdateAudioClips(startEventAudioclips);
        }
        else if (eventManager.event1Invoked == true)
        {
            UpdateAudioClips(event1Audioclips);
        }
        else if (eventManager.event2Invoked == true)
        {
            UpdateAudioClips(event2Audioclips);
        }
    }

    //step 3: Transfer to list to currentaudioclips
    public void UpdateAudioClips(List<AudioClip> audioClipsToTranfer)
    {
        currentAudioClips.Clear();
        foreach (AudioClip clipToTranfer in audioClipsToTranfer)
        {
            currentAudioClips.Add(clipToTranfer);
        }

        Debug.Log("Update Audio Clips " + currentAudioClips[1]);

        NextAudioClip();
    }

    //step 4: Play the audio clips
    public void NextAudioClip()
    {
        Debug.Log("in NextAudioClip");
        Debug.Log("audioIndex: " + audioIndex + "currentaudioclip count: " + currentAudioClips.Count + "audiosource is playering: " + mentorAudioSource.isPlaying);
        if (!mentorAudioSource.isPlaying && audioIndex < currentAudioClips.Count)
        {
            Debug.Log("currentAudioclips: " + currentAudioClips.Count);
            mentorAudioSource.clip = currentAudioClips[audioIndex];
            mentorAudioSource.Play();
            audioIndex++;
        }
        else if (audioIndex > currentAudioClips.Count)
        {
            audioIndex = 0;
        }

    }

    



    //public void CheckCurrentEvent(EventManager.CurrentEvent currentEvent)
    //{
    //    switch (currentEvent) 
    //    {
    //        case (EventManager.CurrentEvent.EVENT1):
    //            UpdateAudioClips(event1Audioclips);
    //            break;

    //        case (EventManager.CurrentEvent.EVENT2):
    //            UpdateAudioClips(event2Audioclips);
    //            break;
    //    }

    //}





}
