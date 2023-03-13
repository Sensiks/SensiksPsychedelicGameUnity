using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TrackGenerator), true), CanEditMultipleObjects]
public class TrackGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        TrackGenerator trackCreator = (TrackGenerator)target;
        if(GUILayout.Button("Generate Track"))
        {
            trackCreator.GenerateTrack();
        }

    }
}

