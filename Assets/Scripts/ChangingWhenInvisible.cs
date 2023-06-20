using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingWhenInvisible : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ChangingEventManager changingEventManager;
    [SerializeField] private Camera playerCamera;
    private MeshRenderer objectRenderer;
    public List<GameObject> objectPool;
    public Transform spawnLocation;
    
    

    [Header("Stuff to keep track off")]
    private int currentinx = 0;
    public bool changerActive;
    [HideInInspector] public bool shovelChangedAndSeen;
    public float amountOfObjectChanged;

    [Header("ObjectReferences")]
    [SerializeField] private GameObject lever;
    [SerializeField] private GameObject newObject;

    void Start()
    {
        UpdateList();
        objectRenderer = objectPool[currentinx].GetComponent<MeshRenderer>();

    }
    public void ChangeObjectActivator(bool OnorOff)
    {
        changerActive = OnorOff;
    }

    private void Update()
    {
        //Debug.Log("objectpool list: " + objectPool[currentinx]);
        if (changerActive)
        {
            Debug.Log("changerActive");
            // Check if the object is within the camera's view frustum
            if (IsVisibleFromCamera())
            {
                // Object is visible
                Debug.Log("Object is visible");
                if (amountOfObjectChanged >= 1)
                {
                    shovelChangedAndSeen = true;
                }

            }
            else
            {
                // Object is not visible
                Debug.Log("Object is not visible");
                SwitchObject();
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
        currentinx++;
        
        if (currentinx >= objectPool.Count)
        {
            Debug.Log("currentinx: " + currentinx + "objectpool.count: " + objectPool.Count);
            currentinx = 0;
        }

        objectPool[currentinx].SetActive(true);
        shovelChangedAndSeen = true;
        amountOfObjectChanged++;
    }

    private bool IsVisibleFromCamera()
    {
        objectRenderer = objectPool[currentinx].GetComponent<MeshRenderer>();
        Debug.Log("objectMeshRenderer: " + objectRenderer);
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

    public void ChangeLever()
    {
        if (changingEventManager.ChangingEvent1Invoked == true)
        {
            lever.SetActive(false);
            newObject.SetActive(true);
        }

    }

}
