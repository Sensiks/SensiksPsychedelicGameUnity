using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensiks.SDK.UnityLibrary;
using Sensiks.SDK.Shared.SensiksDataTypes;

public class FurnaceManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ParticleSystem fireParticle, smokeParticle;
    [SerializeField] private SensificationManager sensiManager;
    [SerializeField] private TerrainManager terrainManager;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject fireLight;

    [Header("Stuff to keep track off")]
    [SerializeField] private bool wantsCoalSmellOn;
    [SerializeField] private float minDistance, maxDistance;
    private float distanceToPlayer;
    private bool fireOn;

    // Start is called before the first frame update
    void Start()
    {
        
        FireOff();
    }

    // Check if player is close to furnace, if so change smell to coal and turn heaters on.
    // if not turn off heaters and return smell to swamp or forest
    void FixedUpdate()
    {
        distanceToPlayer = Vector3.Distance(player.position, fireParticle.GetComponent<Transform>().position);

        if (distanceToPlayer >= minDistance && distanceToPlayer <= maxDistance && fireOn == true)
        {
            SensiksManager.SetHeaterIntensity(HeaterPosition.LEFT, 0.5f);
            SensiksManager.SetHeaterIntensity(HeaterPosition.RIGHT, 0.5f);

            if (wantsCoalSmellOn)
            {
                sensiManager.SetNewSmell(SensificationManager.EnumScent.COAL);
            }
            
            Debug.Log("heater on");
        } else
        {
            //sensiManager.SetNewSmell(SensificationManager.EnumScent.SWAMP);
            SensiksManager.SetHeaterIntensity(HeaterPosition.LEFT, 0f);
            SensiksManager.SetHeaterIntensity(HeaterPosition.RIGHT, 0f);

            //sensiManager.StopSmellRelease();

            if(terrainManager.changeTerrainActive == false)
            {
                sensiManager.SetNewSmell(SensificationManager.EnumScent.SWAMP);
            }
            else if(terrainManager.changeTerrainActive == true)
            {
                sensiManager.SetNewSmell(SensificationManager.EnumScent.FOREST);
            }
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
