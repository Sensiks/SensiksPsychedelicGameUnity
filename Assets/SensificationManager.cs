using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensiks.SDK.UnityLibrary;
using Sensiks.SDK.Shared.SensiksDataTypes;

public class SensificationManager : MonoBehaviour
{

    public enum EnumScent
    {
        FOREST, SWAMP, COAL
    }


    void ScentTrigger()
    {

        SensiksManager.SetActiveScent(Scent.MISTY_SWAMP, 1f);
    }
}
