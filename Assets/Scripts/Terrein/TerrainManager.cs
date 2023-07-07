using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    [Header("Terrain Tiles")]
    [SerializeField] public List<GameObject> forrestTerrains;
    [SerializeField] public List<GameObject> swampTerrains;

    [Header("Stuff to keep track off")]
    public int quarterIndx, changedTerrains;
    public bool changeTerrainActive;

    //Toggles Terrain changer on and off.
    public void ChangeTerrainActivator(bool OnorOff)
    {
        changeTerrainActive = OnorOff;
    }
}
