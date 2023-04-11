using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MentorDialogueSystem : MonoBehaviour
{
    public AudioSource source1;
    [SerializeField]
    private List<AudioClip> currentAudioClips;
    private int audioIndex = 0;

    [Header("Event 1")]
    public List<AudioClip> event1Audioclips;


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

    public void Update()
    {
        switch(EventManager)
    }

    public void UpdateAudioClips(List<AudioSource> audioClipsToTranfer)
    {
        currentAudioClips.Clear();
        foreach(AudioClip clipToTranfer in event1Audioclips)
        {
            currentAudioClips.Add(clipToTranfer);
        }
    }


}
