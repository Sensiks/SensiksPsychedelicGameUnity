using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MentorDialogueSystem : MonoBehaviour
{
    [Header("References")]
    public AudioSource mentorAudioSource;
    public TutorialEventManager tutorialEventManager;
    public ChangingEventManager changingEventManager;
    public GameObject mentor;

    [Header("StuffToKeepTrack off")]
    private int audioIndex = 0;
    private int nmr = 0;
    public List<AudioClip> currentAudioClips;

    [Header("TutorialEvents")]
    public List<AudioClip> tutorialEvent1;
    public List<AudioClip> tutorialEvent2;
    public List<AudioClip> tutorialEvent3;
    public List<AudioClip> tutorialEvent4;

    [Header("ChangingEvent Audioclips")]
    public List<AudioClip> ChangeEvent1;

    [Header("MentorScaler")]
    public float updateStep = 0.1f;
    public int sampleDataLength = 1024;
    private float currentUpdateTime = 0f;
    public float clipLoudness;
    private float[] clipSampleData;
    public float sizeFactor = 1f;
    public float minSize = 0;
    public float maxSize = 500;

    public void Awake()
    {
        clipSampleData = new float[sampleDataLength];
    }


    //step 1: Listen to for an event
    private void Start()
    {
        //mentorAudioSource = GetComponent<AudioSource>();
        tutorialEventManager.tutorialEvent1.AddListener(NewAudioClipList);
        tutorialEventManager.tutorialEvent2.AddListener(NewAudioClipList);
        tutorialEventManager.tutorialEvent3.AddListener(NewAudioClipList);
        tutorialEventManager.tutorialEvent4.AddListener(NewAudioClipList);
        changingEventManager.ChangeEvent1.AddListener(NewAudioClipList);
        changingEventManager.ChangeEvent2.AddListener(NewAudioClipList);
    }

    public void FixedUpdate()
    {
        NextAudioClip();
    }

    public void Update()
    {
        MentorScaleWhileTalk();
        
    }

    //step 2: Choose a new list to listen to
    private void NewAudioClipList()
    {
        if (tutorialEventManager.tutorialEvent1Invoked == true)
        {
            UpdateAudioClips(tutorialEvent1);
        }
        else if (tutorialEventManager.tutorialEvent2Invoked == true)
        {
            Debug.Log("tutorialevent2: " + tutorialEventManager.tutorialEvent2Invoked);
            UpdateAudioClips(tutorialEvent2);
            
        }
        else if (tutorialEventManager.tutorialEvent3Invoked == true)
        {
            Debug.Log("tutorialevent3: " + tutorialEventManager.tutorialEvent3Invoked);
            UpdateAudioClips(tutorialEvent3);
            
        }
        else if (tutorialEventManager.tutorialEvent4Invoked == true)
        {
            Debug.Log("tutorialevent4: " + tutorialEventManager.tutorialEvent4Invoked);
            UpdateAudioClips(tutorialEvent4);
            
        }
        else if (changingEventManager.ChangingEvent1Invoked == true)
        {
            Debug.Log("ChangingEvent1: " + changingEventManager.ChangingEvent1Invoked);
            UpdateAudioClips(ChangeEvent1);
        }
    }

    //step 3: Transfer to list to currentaudioclips
    public void UpdateAudioClips(List<AudioClip> audioClipsToTranfer)
    {
        
        Debug.Log("UpdateAudioClips before foreach: " + nmr);
        currentAudioClips.Clear();
        
        foreach (AudioClip clipToTranfer in audioClipsToTranfer)
        {
            Debug.Log("cliptoTransfer: " + clipToTranfer);
            currentAudioClips.Add(clipToTranfer);
        }

        Debug.Log("Update Audio Clips after foreach: " + currentAudioClips[nmr]);

        nmr++;
        
    }

    //step 4: Play the audio clips
    public void NextAudioClip()
    {
        //Debug.Log("in NextAudioClip");
        //Debug.Log(currentAudioClips);
        //Debug.Log("audioIndex: " + audioIndex + "currentaudioclip count: " + currentAudioClips.Count + "audiosource is playering: " + mentorAudioSource.isPlaying);
        if (!mentorAudioSource.isPlaying && audioIndex < currentAudioClips.Count)
        {
            mentorAudioSource.clip = currentAudioClips[audioIndex];
            mentorAudioSource.Play();
            Debug.Log("currentclip: " + mentorAudioSource.clip);
            audioIndex++;
            NextAudioClip();
        }
        else if (audioIndex > currentAudioClips.Count)
        {
            audioIndex = 0;
        }

    }

    // SCALE MENTOR WHILE IT IS TALKING
    public void MentorScaleWhileTalk()
    {
        currentUpdateTime += Time.deltaTime;
        if (currentUpdateTime >= updateStep)
        {
            currentUpdateTime = 0f;
            mentorAudioSource.clip.GetData(clipSampleData, mentorAudioSource.timeSamples); //I read 1024 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
            clipLoudness = 0f;
            foreach (var sample in clipSampleData)
            {
                clipLoudness += Mathf.Abs(sample);
            }
            clipLoudness /= sampleDataLength; //clipLoudness is what you are looking for

            clipLoudness *= sizeFactor;
            clipLoudness = Mathf.Clamp(clipLoudness, minSize, maxSize);
            mentor.transform.localScale = new Vector3(clipLoudness, clipLoudness, clipLoudness);
        }
    }

}
