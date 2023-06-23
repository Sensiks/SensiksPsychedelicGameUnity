using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingWhenInvisible : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ChangingEventManager changingEventManager;
    [SerializeField] private Camera playerCamera;

    public List<GameObject> objectPoolShovel;

    [Header("Stuff to keep track off")]
    private int currentinx = 0;
    public bool changerActive;
    public float amountOfObjectChanged;

    [Header("Shovel")]
    public bool replaceShovel;
    private MeshRenderer objectRendererShovel;
    public bool shovelChangedAndSeen;

    [Header("Lever")]
    [SerializeField] private bool replaceLever;
    [SerializeField] private GameObject lever;
    [SerializeField] private GameObject leverReplacement;
    public bool leverIsReplaced;

    [Header("CoalStack")]
    public bool replaceCoalStack;
    [SerializeField] private GameObject coalStack;
    [SerializeField] private GameObject coalStackReplacement;
    private MeshRenderer objectRendererCoalStack;

    void Start()
    {
        UpdateList();
        objectRendererShovel = objectPoolShovel[currentinx].GetComponent<MeshRenderer>();
        objectRendererCoalStack = coalStack.GetComponent<MeshRenderer>();

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
                if (shovelChangedAndSeen == false)
                {
                    // Object is not visible
                    Debug.Log("Object is not visible");
                    SwitchObject();
                }
                else if (replaceCoalStack == true)
                {
                    SwitchCoalStack();
                }
                
            }
        }
    }


    private void UpdateList()
    {
        foreach (GameObject child in transform)
        {
            objectPoolShovel.Add(child);
        }
    }

    private void SwitchObject()
    {
        Transform oldposition = objectPoolShovel[currentinx].transform;
        objectPoolShovel[currentinx].SetActive(false);
        currentinx++;
        
        if (currentinx >= objectPoolShovel.Count)
        {
            Debug.Log("currentinx: " + currentinx + "objectpool.count: " + objectPoolShovel.Count);
            currentinx = 0;
        }

        objectPoolShovel[currentinx].SetActive(true);
        objectPoolShovel[currentinx].transform.position = oldposition.position;
        shovelChangedAndSeen = true;
        amountOfObjectChanged++;
    }

    private bool IsVisibleFromCamera()
    {
        objectRendererShovel = objectPoolShovel[currentinx].GetComponent<MeshRenderer>();
        Bounds bounds = objectRendererShovel.bounds;
        //for the shovel
        if (replaceShovel == true && shovelChangedAndSeen == false)
        {   
            
            Debug.Log("objectMeshRenderer: " + objectRendererShovel);
            // If the object has no renderer or is not enabled, consider it invisible
            if (objectRendererShovel == null || !objectRendererShovel.enabled)
            {
                return false;
            }

            // Get the object's bounds
            bounds = objectRendererShovel.bounds;
        }
        //for the coalstack
        else if(replaceCoalStack == true)
        {
            objectRendererCoalStack = coalStack.GetComponent<MeshRenderer>();
            Debug.Log("objectMeshRenderer: " + objectRendererCoalStack);
            // If the object has no renderer or is not enabled, consider it invisible
            if (objectRendererCoalStack == null || !objectRendererCoalStack.enabled)
            {
                return false;
            }

            // Get the object's bounds
            bounds = objectRendererCoalStack.bounds;
        }

        // Check if the bounds intersect with the camera's view frustum
        if (GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(playerCamera), bounds))
        {
            return true;
        }

        return false;
    }

    public void SwitchCoalStack()
    {
        coalStack.SetActive(false);
        coalStackReplacement.SetActive(true);
    }

    public void ChangeLever()
    {
        if (replaceLever)
        {
            lever.SetActive(false);
            leverReplacement.SetActive(true);
            Debug.Log("ChangeLever");

        }
    }

    public void ActivateChangeLever(bool activate)
    {
        replaceLever = activate;
    }

    public void ChangeShovel()
    {

    }

}
