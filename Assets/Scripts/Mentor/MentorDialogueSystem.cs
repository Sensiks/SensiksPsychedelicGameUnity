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

    [Header("TutorialEvents")]
    public List<AudioClip> tutorialEvent1;
    public List<AudioClip> tutorialEvent2;
    public List<AudioClip> tutorialEvent3;
    public List<AudioClip> tutorialEvent4;

    [Header("Update step")]
    private float currentUpdateTime = 0f;

    //step 1: Listen to for an event
    private void Start()
    {
        //mentorAudioSource = GetComponent<AudioSource>();
        eventManager.tutorialEvent1.AddListener(NewAudioClipList);
        eventManager.tutorialEvent2.AddListener(NewAudioClipList);
        eventManager.tutorialEvent3.AddListener(NewAudioClipList);
        eventManager.tutorialEvent4.AddListener(NewAudioClipList);
    }
    
    //step 2: Choose a new list to listen to
    private void NewAudioClipList()
    {
        Debug.Log("in new audiocliplist");

        if (eventManager.tutorialEvent1Invoked == true)
        {
            UpdateAudioClips(tutorialEvent1);
        }
        else if (eventManager.tutorialEvent2Invoked == true)
        {
            UpdateAudioClips(tutorialEvent2);
        }
        else if (eventManager.tutorialEvent3Invoked == true)
        {
            UpdateAudioClips(tutorialEvent3);
        }
        else if (eventManager.tutorialEvent4Invoked == true)
        {
            UpdateAudioClips(tutorialEvent4);
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
    // SCALE MENTOR WHILE IT IS TALKING
    //public void MentorScaleWhileTalk()
    //{
    //    currentUpdateTime += Time.deltaTime;
    //    if (currentUpdateTime >= updateStep)
    //    {
    //        currentUpdateTime = 0f;
    //        mentorAudioSource.clip.GetData(clipSampleData, audioSource.timeSamples); //I read 1024 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
    //        clipLoudness = 0f;
    //        foreach (var sample in clipSampleData)
    //        {
    //            clipLoudness += Mathf.Abs(sample);
    //        }
    //        clipLoudness /= sampleDataLength; //clipLoudness is what you are looking for

    //        clipLoudness *= sizeFactor;
    //        clipLoudness = Mathf.Clamp(clipLoudness, minSize, maxSize);
    //        cube.transform.localScale = new Vector3(clipLoudness, clipLoudness, clipLoudness);
    //    }
    //}
}
