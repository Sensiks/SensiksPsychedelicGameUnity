using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingWhenInvisible : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    private MeshRenderer objectRenderer;
    public List<GameObject> objectPool;
    private int currentinx = 0;
    public Transform spawnLocation;
    public bool changerActive;


    void Start()
    {
        UpdateList();
        objectRenderer = objectPool[currentinx].GetComponent<MeshRenderer>();
        
    }

    public void TurnOnChanger(bool onOff)
    {
        changerActive = onOff;
    }

    private void Update()
    {
        Debug.Log("objectpool list: " + objectPool[currentinx]);
        if (changerActive)
        {
            // Check if the object is within the camera's view frustum
            if (IsVisibleFromCamera())
            {
                // Object is visible
                Debug.Log("Object is visible");

            }
            else
            {
                // Object is not visible
                Debug.Log("Object is not visible");
                //SwitchObject();
            }
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
        objectRenderer = objectPool[currentinx].GetComponent<MeshRenderer>();

        if (currentinx >= objectPool.Count)
        {
            currentinx = 0;
        }
    }

    private bool IsVisibleFromCamera()
    {
        Debug.Log("objectRenderer: " + objectRenderer);
        // If the object has no renderer or is not enabled, consider it invisible
        if (objectRenderer == null || !objectRenderer.enabled)
        {
            return false;
        }

        

        // Get the object's bounds
        Bounds bounds = objectRenderer.bounds;

        // Check if the bounds intersect with the camera's view frustum
        if (GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(playerCamera), bounds))
        {
            return true;
        }

        return false;
    }

}
