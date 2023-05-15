using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class TrainManager : MonoBehaviour
{
    [SerializeField]
    private CinemachineDollyCart train;
    

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void TrainSpeedChanger(float newSpeed)
    {
        train.m_Speed = newSpeed;
    }
}
