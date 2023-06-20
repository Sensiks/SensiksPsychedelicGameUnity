using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TrainManager : MonoBehaviour
{
    [Header("SpeedChanger")]
    [SerializeField] private CinemachineDollyCart train;
    [SerializeField] private CinemachineDollyCart coalCart;
    [SerializeField] private CinemachineDollyCart coupe;

    [Header("References")]
    [SerializeField] private CircularDrive circularDriveLever;

    [Header("Audio Stuff")]
    [SerializeField] private AudioSource trainAudioSource;
    [SerializeField] private AudioClip trainBackgroundSound;
    [SerializeField] private AudioSource wistleAudioSource;
    [SerializeField] private AudioClip wistleSound;
    private bool isTriggered;

    public bool leverActive;
    private float acceleration = 0.3f;
    private float currentSpeed = 0f;


    private void Start()
    {

    }

    private void FixedUpdate()
    {
        ActivateLever();
    }

    public void TrainSpeedChanger(float newSpeed)
    {
        StartCoroutine(IncreaseSpeed(newSpeed));

        if (train.m_Speed > 0f)
        {
            trainAudioSource.clip = trainBackgroundSound;
            trainAudioSource.Play();
            trainAudioSource.loop = true;
        }
    }

    private IEnumerator IncreaseSpeed(float newSpeed)
    {
        while (currentSpeed < newSpeed)
        {
            currentSpeed += acceleration * Time.deltaTime;

            train.m_Speed = currentSpeed;
            coalCart.m_Speed = currentSpeed;
            coupe.m_Speed = currentSpeed;

            yield return null;
        }
    }

    //if lever is at max angle, leverActive = true pressure goes down and wistle sound is played
    public void ActivateLever()
    {
        
        // needs to be actived ones not every frame.
        if (circularDriveLever.outAngle >= circularDriveLever.maxAngle - 0.5f)
        {
            leverActive= true;
            if(isTriggered == false)
            {
                wistleAudioSource.clip = wistleSound;
                wistleAudioSource.Play();
                wistleAudioSource.loop = true;
                isTriggered= true;  
            }
            
        }
        else
        {
            leverActive = false;
            wistleAudioSource.Stop();
            isTriggered = false;    
            
        }

        //if(circularDriveLever.outAngle >= circularDriveLever.maxAngle - 0.5f || circularDriveLever.outAngle <= circularDriveLever.minAngle + 0.5f)
        //{
        //    lockingSoundSource.Play();
        //    Activated = true;
        //}
        
        //Debug.Log("HandelActive: " + leverActive);


    }
}
