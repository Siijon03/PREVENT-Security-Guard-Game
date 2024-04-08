using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police_Tracker : MonoBehaviour
{
    public GameObject police_Ref;
    public Vector3 spawnedObjectOffset;

    public Transform trackObjectTransform;


    // Start is called before the first frame update
    void Start()
    {
        if(police_Ref != null)
        {
            trackObjectTransform = police_Ref.transform;
        }
    }

    void LateUpdate()
    {
        Debug.Log("Attached Dog");

        if (trackObjectTransform != null)
        {
            Vector3 newPosition = trackObjectTransform.position + spawnedObjectOffset;

            transform.position = newPosition;
            transform.rotation = trackObjectTransform.rotation;
        }
        else
        {
            Debug.LogError("Object to spawn is not assigned!");
        }
    }
}
