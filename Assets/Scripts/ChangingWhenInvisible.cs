using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingWhenInvisible : MonoBehaviour
{
    public List<GameObject> objectPool;
    private int currentinx = 0;
    public Transform spawnLocation;
    public bool changerActive;


    void Start()
    {

        UpdateList();
        
    }

    public void TurnOnChanger(bool onOff)
    {
        changerActive = onOff;
    }

    //private void Update()
    //{

    //    MeshRenderer meshRenderer = objectPool[currentinx].GetComponent<MeshRenderer>();
    //    Debug.Log("Meshrenderer visible" + meshRenderer.isVisible);
        
    //    if (!meshRenderer.isVisible && changerActive == true)
    //    {
    //        Debug.Log("The mesh renderer is not visible to the player.");
    //        SwitchObject();
    //    }  
    //}

    public void OnBecameVisible()
    {
        Debug.Log("IsVisable");
    }

    public void OnBecameInvisible()
    {

        Debug.Log("iam invisible");
        if (changerActive)
        {
            SwitchObject();
        }

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

        if(currentinx >= objectPool.Count)
        {
            currentinx = 0;
        }
    }

    private void Eventriggers()
    {

    }

}
