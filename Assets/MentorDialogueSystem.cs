using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MentorDialogueSystem : MonoBehaviour
{
    public AudioSource source1;
    private List<AudioClip> currentAudioClips;
    private int audioIndex = 0;

    public List<AudioClip> event1Audioclips;

    [Header("GameEvent")]
    public GameEvent NextEvent;

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

    public void UpdateAudioClips()
    {
        currentAudioClips.Clear();
        foreach(AudioClip clipToTranfer in event1Audioclips)
        {
            currentAudioClips.Add(clipToTranfer);
        }
    }
    

}
