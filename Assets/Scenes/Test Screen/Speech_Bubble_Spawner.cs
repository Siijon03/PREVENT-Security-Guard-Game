using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speech_Bubble_Spawner : MonoBehaviour
{
    //Reference A Sprite in the Unity Editor.
    public GameObject speechBubbleReference;
    //Object to replace the spawned object.
    public GameObject replacementObject;

    // Offset from the parent object's position.
    public Vector2 bubbleOffset;

    // Time in seconds before replacement.
    public float replacementDelay = 10f;

    private float spawnTime;


    // Start is called before the first frame update
    void Start()
    {
        SpawnObject();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - spawnTime >= replacementDelay && replacementObject != null)
        {
            ReplaceSpawnedObject();
        } 
    }

    public void SpawnObject()
    {
        if (speechBubbleReference != null)
        {
            Vector2 spawnPosition = (Vector2)transform.position + bubbleOffset;
            GameObject spawnedObject = Instantiate(speechBubbleReference, spawnPosition,Quaternion.identity);

            //Set the spawned object's parent to the current object.
            spawnedObject.transform.parent = transform;

            //Record the Spawn Time.
            spawnTime = Time.time;
        }
        else
        {
            Debug.LogError("Speech Bubble was Not Spawned.");
        }
    }

    public void ReplaceSpawnedObject()
    {
        //Replace the Spawned Speech Bubble with the Replacement Object.
        Destroy(transform.GetChild(0).gameObject);
        //Spawn Replacement Object.
        Instantiate(replacementObject,(Vector2) transform.position + bubbleOffset, Quaternion.identity);
    }
}
