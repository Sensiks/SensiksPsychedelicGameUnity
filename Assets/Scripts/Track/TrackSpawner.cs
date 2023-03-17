using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TrackSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject straightPrefab, shortStraightPrefab, leftTurnPrefab, rightTurnPrefab;

    [SerializeField]
    private GameObject startingTrack;

    private TrackGenerator trackGenerator;

    private Vector3 spawnPointNewTrack;

    private int maxTrackAmount;

    private int amountOfTrack;
    private int trackInFrontTrain;
    private int lastWayPoint;

    private float distanceTraintoEnd;

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
        if ()
        {

        }
        lastWayPoint = trackGenerator.waypointCount;
    }

    public void MakeTrack(SortOfTrack sortOfTrack)
    {
        spawnPointNewTrack = trackGenerator.generatedWaypoints[lastWayPoint].position;
        switch (sortOfTrack)
        {
            case SortOfTrack.STRAIGHT:
                {

                    Instantiate(straightPrefab, spawnPointNewTrack, Quaternion.identity);

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
}
