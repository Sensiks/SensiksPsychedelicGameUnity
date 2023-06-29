using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensiks.SDK.UnityLibrary;
using Sensiks.SDK.Shared.SensiksDataTypes;

public class WindSense : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            Debug.Log("Turn on fan");
            SensiksManager.SetFanIntensity(FanPosition.FRONT_LEFT, 0.5f);
            SensiksManager.SetFanIntensity(FanPosition.FRONT_RIGHT, 0.5f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Debug.Log("Turn off fan");
            SensiksManager.SetFanIntensity(FanPosition.FRONT_LEFT, 0f);
            SensiksManager.SetFanIntensity(FanPosition.FRONT_RIGHT, 0f);
        }
    }
}
