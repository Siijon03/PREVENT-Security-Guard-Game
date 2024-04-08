using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talking_Test_Scr_Level_3 : MonoBehaviour
{
    public GameObject bubbleFrame;
    public GameObject speakingObject;
    public GameObject speakingObjectReplacement;

    public Vector2 spawnedObjectOffset;

    public float emotionSpawnDelay = 10.0f;
    public float replacementEmotionSpawnDelay = 20.0f;
    public float zOffset = 0f;

    private bool hasObjectSpawned = false;
    private bool isObjectReplaced = false;
    private float spawnTime;
    private float replacementTime;


    // Start is called before the first frame update
    void Start()
    {
        SpawnObject();
    }


    // Update is called once per frame
    void Update()
    {
        if (!hasObjectSpawned && Time.time - spawnTime >= emotionSpawnDelay)
        {
            SpawnSecondObject();
            hasObjectSpawned = true;
        }

        if (!isObjectReplaced && Time.time - replacementTime >= replacementEmotionSpawnDelay)
        {
            ReplaceSecondObject();
            isObjectReplaced = true;
        }
    }

    void SpawnObject()
    {
        Debug.Log("Spawned Speech Bubble");

        if (bubbleFrame != null)
        {
            Vector2 spawnPosition = (Vector2)transform.position + spawnedObjectOffset;
            Instantiate(bubbleFrame, spawnPosition, Quaternion.identity, transform); // Spawn as a child of the current object
            spawnTime = Time.time; // Record the spawn time
        }
        else
        {
            Debug.LogError("Object to spawn is not assigned!");
        }
    }

    void SpawnSecondObject()
    {
        Debug.Log("Spawned Talking Emotion");

        if (bubbleFrame != null && speakingObject != null)
        {
            GameObject spawnedObject = transform.GetChild(0).gameObject; // Get the first spawned object

            // Calculate position in front of the speech bubble
            Vector3 spawnPosition = spawnedObject.transform.position + spawnedObject.transform.forward * 2;

            GameObject secondSpawnedObject = Instantiate(speakingObject, spawnPosition, Quaternion.identity, spawnedObject.transform); // Spawn the second object as a child of the first spawned object
            secondSpawnedObject.transform.localScale = Vector3.one * 6.666667f; // Increase the local scale of the second spawned object
            secondSpawnedObject.transform.localPosition = new Vector3(0f, 0f, zOffset); // Adjust local position to ensure it's in front
        }
        else
        {
            Debug.LogError("Object to spawn is not assigned!");
        }
    }

    void ReplaceSecondObject()
    {
        Debug.Log("Replaced Talking Emotion");

        if (bubbleFrame != null && speakingObject != null && speakingObjectReplacement != null)
        {
            GameObject spawnedObject = transform.GetChild(0).gameObject; // Get the first spawned object
            Vector2 secondSpawnPosition = spawnedObject.transform.position; // Use the position of the first spawned object
            GameObject secondSpawnedObject = Instantiate(speakingObjectReplacement, secondSpawnPosition, Quaternion.identity); // Spawn the second object
            secondSpawnedObject.transform.SetParent(spawnedObject.transform); // Set the second spawned object as a child of the first spawned object
            //secondSpawnedObject.transform.localPosition = spawnedObjectOffset; // Adjust local position
        }
        else
        {
            Debug.LogError("Replacement object is not assigned!");
        }
    }
}

