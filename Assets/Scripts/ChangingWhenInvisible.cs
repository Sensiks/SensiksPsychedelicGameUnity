using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingWhenInvisible : MonoBehaviour
{
    public List<GameObject> objectPool;
    private int currentinx = 0;
    public Transform spawnLocation;   


    void Start()
    {
        UpdateList();
        
    }

    
    public void OnBecameVisible()
    {
        Debug.Log("IsVisable");
    }

    public void OnBecameInvisible()
    {
        
        Debug.Log("iam invisible");
        SwitchObject();
    }

    private void UpdateList()
    {
        foreach (GameObject child in transform)
        {
            objectPool.Add(child);
        }
    }

    private void SwitchObject()
    {
        objectPool[currentinx].SetActive(false);
        objectPool[currentinx + 1].SetActive(true);
        currentinx++;
    }

}
