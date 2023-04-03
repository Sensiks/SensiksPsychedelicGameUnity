using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTerrein : MonoBehaviour
{

    public GameObject oldTerrain;
    public GameObject newTerrain;

    private MeshRenderer myMeshrenderer;

    private void Start()
    {
        myMeshrenderer = GetComponent<MeshRenderer>();
    }
    private void OnBecameInvisible()
    {

        Debug.Log("invis");
        oldTerrain.SetActive(false);
        newTerrain.SetActive(true);
        myMeshrenderer.enabled = false;
        

    }



}
