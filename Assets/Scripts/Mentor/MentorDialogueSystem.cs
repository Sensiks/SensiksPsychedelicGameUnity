using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MentorDialogueSystem : MonoBehaviour
{
    public AudioSource mentorAudioSource;

    private int audioIndex = 0;
    public EventManager eventManager;
    
    private List<AudioClip> currentAudioClips;

    [Header("StarterEvent Audioclips")]
    public List<AudioClip> starteventAudioclips;

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
        if (eventManager.starteventInvoked == true)
        {
            Debug.Log("new audio clip list start event");
            Debug.Log(starteventAudioclips);
            UpdateAudioClips(starteventAudioclips);
        }
        else if (eventManager.event1Invoked == true)
        {
            UpdateAudioClips(starteventAudioclips);
        }
        else if (eventManager.event2Invoked == true)
        {
            UpdateAudioClips(starteventAudioclips);
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
        NextAudioClip();
    }

    //step 4: Play the audio clips
    public void NextAudioClip()
    {
        if (!mentorAudioSource.isPlaying && audioIndex < currentAudioClips.Count)
        {
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
