using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    [SerializeField] public List<GameObject> forrestTerrains;
    [SerializeField] public List<GameObject> swampTerrains;
    public int quarterIndx, changedTerrains;
    public bool changeTerrainActive;

    //Toggles Terrain changer on and off.
    public void ChangeTerrainActivator(bool OnorOff)
    {
        changeTerrainActive = OnorOff;
    }
}
