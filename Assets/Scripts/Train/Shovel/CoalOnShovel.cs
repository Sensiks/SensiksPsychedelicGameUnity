using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalOnShovel : MonoBehaviour
{
    [SerializeField]
    private GameObject coalsOnShovel;

    [HideInInspector]
    public bool coalIsOnShovel;

    //if shovel touches coal in cart 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CoalsInCart"))
        {
            Debug.Log("coals on shovel trigger");
            ShovelSwitch(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        ShovelSwitch(false);
    }

    public void ShovelSwitch(bool isOnShovel)
    {
        coalsOnShovel.SetActive(isOnShovel);
    }
}
