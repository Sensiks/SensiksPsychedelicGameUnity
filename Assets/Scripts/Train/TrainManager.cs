using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class TrainManager : MonoBehaviour
{
    [SerializeField] private CinemachineDollyCart train;
    [SerializeField] private AudioSource trainAudioSource;
    [SerializeField] private AudioClip trainBackgroundSound;
    

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void TrainSpeedChanger(float newSpeed)
    {
        train.m_Speed = newSpeed;

        if(train.m_Speed > 0f)
        {
            trainAudioSource.clip = trainBackgroundSound;
            trainAudioSource.Play();
            trainAudioSource.loop = true;
        }
    }
}
