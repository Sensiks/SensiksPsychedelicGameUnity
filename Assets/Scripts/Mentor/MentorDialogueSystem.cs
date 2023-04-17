using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MentorDialogueSystem : MonoBehaviour
{
    public AudioSource source1;
    [SerializeField]
    private List<AudioClip> currentAudioClips;
    private int audioIndex = 0;
    public EventManager eventManager;


    [Header("Event 1")]
    public List<AudioClip> event1Audioclips;

    [Header("Event 2")]
    public List<AudioClip> event2Audioclips;

    private void Start()
    {
        source1 = GetComponent<AudioSource>();
    }
    
    public void NextAudioClip()
    {
        if (!source1.isPlaying && audioIndex < currentAudioClips.Count)
        {
            source1.clip = currentAudioClips[audioIndex];
            source1.Play();
            audioIndex++;
        }
    }

    public void UpdateAudioClips(List<AudioClip> audioClipsToTranfer)
    {
        currentAudioClips.Clear();
        foreach(AudioClip clipToTranfer in audioClipsToTranfer)
        {
            currentAudioClips.Add(clipToTranfer);
        }
    }

    public void CheckCurrentEvent(EventManager.CurrentEvent currentEvent)
    {
        switch (currentEvent) 
        {
            case (EventManager.CurrentEvent.EVENT1):
                UpdateAudioClips(event1Audioclips);
                break;

            case (EventManager.CurrentEvent.EVENT2):
                UpdateAudioClips(event2Audioclips);
                break;
            
        
        }

    }



}
