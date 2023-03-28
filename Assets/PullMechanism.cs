using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullMechanism : MonoBehaviour
{
    public GameObject pull;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "PullMechanism")
        {
            Debug.Log("pull");
        }
    }
}
