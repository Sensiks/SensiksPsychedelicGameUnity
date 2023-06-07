using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class TrainManager : MonoBehaviour
{
    [SerializeField] private CinemachineDollyCart train;
    [SerializeField] private CinemachineDollyCart coalCart;
    [SerializeField] private CinemachineDollyCart coupe;
    [SerializeField] private AudioSource trainAudioSource;
    [SerializeField] private AudioClip trainBackgroundSound;

    private float acceleration = 1f;
    private float currentSpeed = 0f;


    private void Start()
    {

    }

    private void FixedUpdate()
    {

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
            //currentSpeed = Mathf.Min(currentSpeed, newSpeed);

            train.m_Speed = currentSpeed;
            coalCart.m_Speed = currentSpeed;
            coupe.m_Speed = currentSpeed;

            yield return null;
        }
    }
}
