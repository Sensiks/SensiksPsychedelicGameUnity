using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensiks.SDK.UnityLibrary;
using Sensiks.SDK.Shared.SensiksDataTypes;

public class SensificationManager : MonoBehaviour
{
    [SerializeField] private TerrainManager terrainManager;

    public float triggerDuration = 10f;
    public float intervalDuration = 50f;

    private bool smellCanTrigger = false;

    public EnumScent currentScent;

    public Coroutine activeSmellCoroutine;
    
    public enum EnumScent
    {
        FOREST, SWAMP, COAL, NOSMELL
    }

    private void Start()
    {
        smellCanTrigger = true;
        //SensiksManager.ResetActuators();
        SetNewSmell(EnumScent.SWAMP);
        
    }

    public void StartCycle()
    {
        if (smellCanTrigger == true)
        {
            activeSmellCoroutine = StartCoroutine(TriggerSmellCoroutine());
            Debug.Log("activeSmellCoroutine: " + activeSmellCoroutine + "current smell: " + currentScent);
            Debug.Log("StartCycle");
        }
        
    }

    public void StopCycle()
    {
        if (activeSmellCoroutine != null)
        {
            StopCoroutine(activeSmellCoroutine);
            StopSmellRelease();
            activeSmellCoroutine = null;
        }
        else
        {
            Debug.Log("activesmellcoroutine is null");
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
        else
        {
            Debug.Log("newscent == currentscent" + newScent + currentScent);
        }
        
    }

    private IEnumerator TriggerSmellCoroutine()
    {
        
            StartSmellRelease();
            Debug.Log("start smell release");
            yield return new WaitForSeconds(triggerDuration);
            
            Debug.Log("stop smell release");
            StopSmellRelease();
            
            yield return new WaitForSeconds(intervalDuration);

            StartCycle();
        
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
                SensiksManager.SetActiveScent(Scent.SMOKE, 0.3f);
                Debug.Log("Coal Smell triggering");
                break;
        }
    }

    public void StopSmellRelease()
    {
        Debug.Log("instop smell");
        SensiksManager.SetActiveScent(Scent.GRASS, 0);
        SensiksManager.SetActiveScent(Scent.MISTY_SWAMP, 0);
        SensiksManager.SetActiveScent(Scent.SMOKE, 0);
                
    }

    private void OnApplicationQuit()
    {
        StopSmellRelease();
        SensiksManager.SetFanIntensity(FanPosition.FRONT_LEFT, 0f);
        SensiksManager.SetFanIntensity(FanPosition.FRONT_RIGHT, 0f);
        SensiksManager.SetHeaterIntensity(HeaterPosition.LEFT, 0f);
        SensiksManager.SetHeaterIntensity(HeaterPosition.RIGHT, 0f);
        SensiksManager.ResetActuators();

    }

    
}
