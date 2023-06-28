using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensiks.SDK.UnityLibrary;
using Sensiks.SDK.Shared.SensiksDataTypes;

public class SensificationManager : MonoBehaviour
{
    public float triggerDuration = 10f;
    public float intervalDuration = 50f;

    private bool smellIsTriggering = false;

    public EnumScent currentScent;

    public Coroutine activeSmellCoroutine;
    
    public enum EnumScent
    {
        FOREST, SWAMP, COAL
    }

    private void Start()
    {
        //SensiksManager.ResetActuators();
        StartCycle();
    }

    public void StartCycle()
    {
        if (!smellIsTriggering)
        {
            Debug.Log("activeSmellCoroutine: " + activeSmellCoroutine + "current smell: " + currentScent);
            activeSmellCoroutine = StartCoroutine(TriggerSmellCoroutine());
        }
        
    }

    public void StopCycle()
    {
        if (activeSmellCoroutine != null)
        {
            StopCoroutine(activeSmellCoroutine);
            activeSmellCoroutine = null;
        }
    }

    public void SetNewSmell(EnumScent newScent)
    {
        if(newScent != currentScent)
        {
            currentScent = newScent;
            StopCycle();
            StartCycle();
        }
        
    }

    private IEnumerator TriggerSmellCoroutine()
    {
        while (smellIsTriggering == true)
        {
            StartSmellRelease();
            yield return new WaitForSeconds(triggerDuration);

            StopSmellRelease();
            yield return new WaitForSeconds(intervalDuration);

            StartCycle();
        }
    }

    private void StartSmellRelease()
    {
        switch (currentScent)
        {
            case (EnumScent.FOREST):
                SensiksManager.SetActiveScent(Scent.GRASS, 1);
                Debug.Log("Forest Smell triggering");
                break;
            case (EnumScent.SWAMP):
                SensiksManager.SetActiveScent(Scent.MISTY_SWAMP, 1);
                Debug.Log("Swamp Smell triggering");
                break;
            case (EnumScent.COAL):
                SensiksManager.SetActiveScent(Scent.SMOKE, 1);
                Debug.Log("Coal Smell triggering");
                break;
        }
    }

    private void StopSmellRelease()
    {
        SensiksManager.SetActiveScent(Scent.GRASS, 0);
        SensiksManager.SetActiveScent(Scent.MISTY_SWAMP, 0);
        SensiksManager.SetActiveScent(Scent.SMOKE, 0);
                
    }
}
