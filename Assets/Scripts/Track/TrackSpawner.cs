using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TrackSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject straightPrefab;

    [SerializeField]
    private GameObject startingTrack, train, track;

    [SerializeField]
    private TrackGenerator trackGenerator;

    [SerializeField]
    private float maxDistanceTraintoEnd, distanceTraintoEnd;

    [SerializeField]
    private CinemachinePath trackPath;

    [HideInInspector]
    public List<GameObject> Trackpieces;

    private Vector3 spawnPointNewTrack;

    private int lastWayPointIdx;
    public enum SortOfTrack{
        STRAIGHT, LEFT, RIGHT
    }

    // Start is called before the first frame update
    void Start()
    {
        straightPrefab.GetComponent<CinemachinePath>();
    }

    // Update is called once per frame
    void Update()
    {
        
        lastWayPointIdx = trackPath.m_Waypoints.Length -1;
        distanceTraintoEnd = Vector3.Distance(train.transform.position, trackPath.m_Waypoints[lastWayPointIdx].position);

        if (distanceTraintoEnd <= maxDistanceTraintoEnd) 
        {
            MakeTrack(SortOfTrack.STRAIGHT);

        }

        

        trackGenerator.GenerateTrack();

    }

    public void MakeTrack(SortOfTrack sortOfTrack)
    {
        spawnPointNewTrack = trackPath.m_Waypoints[lastWayPointIdx].position;
        switch (sortOfTrack)
        {
            case SortOfTrack.STRAIGHT:
                {
                    Debug.Log("Straight track");
                    var newStraight = Instantiate(straightPrefab, track.transform);
                    newStraight.transform.localPosition = spawnPointNewTrack;
                    Trackpieces.Add(newStraight);

                    break;
                }

            default:
                {
                    Debug.Log("Default");
                    break;
                }

        }

        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, maxDistanceTraintoEnd);

    }
}
