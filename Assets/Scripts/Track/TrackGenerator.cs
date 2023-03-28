using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TrackGenerator : MonoBehaviour
{
    [SerializeField]
    private CinemachinePath track;
    [SerializeField]
    private bool loopedTrack = false;


    public CinemachinePath.Waypoint[] generatedWaypoints;
    public int waypointCount;
    public int currentWaypointIndex = 0;

    /// <summary>
    /// Call when creating a new piece of a path. 
    /// Add new piece as a child to the of the it as a child to the track object.
    /// </summary>
    /// 
    public void GenerateTrack()
    {
        Debug.Log("Generate track");

        if (!track)
        {
            return;
        }
        currentWaypointIndex = 0;

        waypointCount = loopedTrack ? track.transform.childCount : track.transform.childCount + 1;

        generatedWaypoints = new CinemachinePath.Waypoint[waypointCount];

        for(int i = 0; i < track.transform.childCount; i++)
        {
            Transform currentChild = track.transform.GetChild(i);

            if (i == 0 || loopedTrack)
            {
                AddWaypoint(currentChild, 0);
            }

            if (!loopedTrack)
            {
                AddWaypoint(currentChild, 1);
            }
        }
        track.m_Waypoints = generatedWaypoints;
        track.m_Looped = loopedTrack;
        
    }

    void AddWaypoint(Transform child, int idx)
    {
        if (!child.GetComponent<CinemachinePath>()) return;
        CinemachinePath childCinemachinePath = child.GetComponent<CinemachinePath>();
        CinemachinePath.Waypoint wp = childCinemachinePath.m_Waypoints[idx];
        CinemachinePath.Waypoint targetWP = new CinemachinePath.Waypoint();

        targetWP.position = child.localRotation * wp.position + child.localPosition;
        targetWP.tangent = child.localRotation * wp.tangent;
        targetWP.roll = wp.roll;

        generatedWaypoints[currentWaypointIndex] = targetWP;
        currentWaypointIndex++;
    }
}
