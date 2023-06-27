using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensiks.SDK.UnityLibrary;
using Sensiks.SDK.Shared.SensiksDataTypes;

public class FurnaceManager : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem fireParticle, smokeParticle;
    [SerializeField]
    private float minDistance, maxDistance;
    [SerializeField]
    private Transform player;
    [SerializeField] private SensificationManager sensiManager;


    [SerializeField] private GameObject fireLight;

    private float distanceToPlayer;
    private bool fireOn;

    // Start is called before the first frame update
    void Start()
    {
        
        FireOff();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distanceToPlayer = Vector3.Distance(player.position, fireParticle.GetComponent<Transform>().position);

        if (distanceToPlayer >= minDistance && distanceToPlayer <= maxDistance && fireOn == true)
        {
            SensiksManager.SetHeaterIntensity(HeaterPosition.LEFT, 0.5f);
            SensiksManager.SetHeaterIntensity(HeaterPosition.RIGHT, 0.5f);
            sensiManager.SetNewSmell(SensificationManager.EnumScent.COAL);
            Debug.Log("heater on");
        } else
        {
            sensiManager.StopCycle();
            SensiksManager.SetHeaterIntensity(HeaterPosition.LEFT, 0f);
            SensiksManager.SetHeaterIntensity(HeaterPosition.RIGHT, 0f);
            Debug.Log("heater off");
        }
    }

    public void FireOn(){
        fireParticle.Play();
        smokeParticle.Play();
        fireLight.SetActive(true);
        fireOn = true;
    }

    public void FireOff()
    {
        fireParticle.Stop();
        smokeParticle.Stop();
        fireLight.SetActive(false);
        fireOn = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, minDistance);
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }
}
