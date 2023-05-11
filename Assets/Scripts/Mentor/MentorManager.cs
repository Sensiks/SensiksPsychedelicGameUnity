using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MentorManager : MonoBehaviour
{ 
    public MentorDialogueSystem mentorDialogueSystem;
    public GameObject mentor;
    public float travelDuration;

    public void MoveNextTransform(Transform nextCheckpoint)
    {
        StartCoroutine(MoveObject(nextCheckpoint));
    }

    IEnumerator MoveObject(Transform nextCheckpoint)
    {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = nextCheckpoint.position;

        float currentTime = 0f;
        float t = 0f;

        while (t < 1f)
        {
            currentTime += Time.deltaTime;
            t = Mathf.Clamp01(currentTime / travelDuration);

            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }

    }

    
}
