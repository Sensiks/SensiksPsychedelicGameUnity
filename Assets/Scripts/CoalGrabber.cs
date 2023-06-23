using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CoalGrabber : MonoBehaviour
{
    [SerializeField] private GameObject coal;
    [SerializeField] private Hand leftHand;
    [SerializeField] private Hand rightHand;
    public int amountPickedUp;

    [SerializeField] private ChangingEventManager changingEventManager;

    private void Start()
    {
        changingEventManager.ChangeEvent3.AddListener(ResetCount);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("other collider: " + other);
        if(other.transform.tag == "LeftHand")
        {
            coal.SetActive(true);
            Debug.Log("CoalGrabber Left");
            leftHand.AttachObject(coal, GrabTypes.Grip, Hand.AttachmentFlags.SnapOnAttach);
            amountPickedUp++;
        }
        else if (other.transform.tag == "RightHand")
        {
            coal.SetActive(true);
            Debug.Log("CoalGrabber Right");
            rightHand.AttachObject(coal, GrabTypes.Grip, Hand.AttachmentFlags.SnapOnAttach);
            amountPickedUp++;
        }
    }

    private void ResetCount()
    {
        amountPickedUp = 0;
    }
}
