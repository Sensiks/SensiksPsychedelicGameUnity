using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TrackSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject straightPrefab, shortStraightPrefab, leftTurnPrefab, rightTurnPrefab;

    [SerializeField]
    private GameObject startingTrack, train;

    private TrackGenerator trackGenerator;
    private GameObject track;

    private Vector3 spawnPointNewTrack;

    private int maxTrackAmount;

    private int amountOfTrack;
    private int trackInFrontTrain;
    private int lastWayPoint;

    private float distanceTraintoEnd;
    [SerializeField]
    private float maxDistanceTraintoEnd;

    public List<GameObject> Trackpieces;
    public enum SortOfTrack{
        STRAIGHT, LEFT, RIGHT
    }

    // Start is called before the first frame update
    void Start()
    {
        Trackpieces.Add(startingTrack);
        

        straightPrefab.GetComponent<CinemachinePath>();
        shortStraightPrefab.GetComponent<CinemachinePath>();
        leftTurnPrefab.GetComponent<CinemachinePath>();
        rightTurnPrefab.GetComponent<CinemachinePath>();
    }

    // Update is called once per frame
    void Update()
    {
        lastWayPoint = trackGenerator.waypointCount;
        distanceTraintoEnd = Vector3.Distance(train.transform.position, trackGenerator.generatedWaypoints[lastWayPoint].position);
        if ( distanceTraintoEnd < maxDistanceTraintoEnd ) 
        {
            MakeTrack(SortOfTrack.STRAIGHT);
        }
       
        
        
    }

    public void MakeTrack(SortOfTrack sortOfTrack)
    {
        spawnPointNewTrack = trackGenerator.generatedWaypoints[lastWayPoint].position;
        switch (sortOfTrack)
        {
            case SortOfTrack.STRAIGHT:
                {

                    var newStraight = Instantiate(straightPrefab, spawnPointNewTrack, Quaternion.identity);
                    newStraight.transform.parent = track.transform;
                    //TrackGenerator.GenerateTrack();

                    break;
                }

            case SortOfTrack.LEFT:
                {
                    break;
                }

            default:
                {
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
