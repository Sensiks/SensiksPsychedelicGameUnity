using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensiks.SDK.UnityLibrary;
using Sensiks.SDK.Shared.SensiksDataTypes;

public class FurnaceManager : MonoBehaviour
{
    private bool fireOn;

    [SerializeField]
    private ParticleSystem fireParticle, smokeparticle;

    private float distanceToPlayer;

    private float minDistance, maxDistance;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        fireParticle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(player.position, fireParticle.GetComponent<Transform>().position);

        if (distanceToPlayer >= minDistance && distanceToPlayer <= maxDistance && fireOn)
        {
            SensiksManager.SetHeaterIntensity(HeaterPosition.FRONT, 0.5f);
            
        }
        else
        {
            SensiksManager.SetHeaterIntensity(HeaterPosition.FRONT, 0f);
        }
    }

    public void FireOn(){
        fireParticle.Play();
        fireOn = true;
    }

    public void FireOff()
    {
        fireParticle.Stop();
        fireOn = false;
    }

}
