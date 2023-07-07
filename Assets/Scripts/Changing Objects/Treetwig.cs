using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treetwig : MonoBehaviour
{
    public bool twigTouchedCoal;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("CoalsInCart")){
            twigTouchedCoal = true;
            Debug.Log("Twig touched coals");
        }
    }
}
