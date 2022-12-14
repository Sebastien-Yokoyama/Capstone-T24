// NAME: Cody Jackson
// EMAIL: codyj@nevada.unr.edu
// COURSE: CS 425/426
// ASSIGNMENT: Senior Project
// FILE NAME: CarSpawner.cs
/* FILE DESCRIPTION: Spawns the Car for Stretch2 scene. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public string desiredName; // The name of the GameObjects to find
    public List<GameObject> foundObjects; // The list of found GameObjects

    // Don't want to spawn the car IN the player.
    public float minSpacingDist = 10f;

    // Reference to the player character
    public GameObject player;

    // The prefab that we want to instantiate
    public GameObject prefabToSpawn;

    // The distance at which we want to instantiate the prefab
    public float spawnDistance = 30f;

    private GameObject newCar;
    public GameObject existingCar;

    void Start()
    {
        // Get all the objects in the scene
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();

        // Loop through the objects and add any that have the specified name to the list
        foreach (GameObject obj in allObjects)
        {
            if (obj.name == desiredName)
            {
                foundObjects.Add(obj);
            }
        }
    }

    void Update()
    {
        
    }

    public void InitiateSpawning()
    {

        // Find the gameobject in the list that is closest to the player
        GameObject closestSpawnPoint = null;
        float closestDistance = float.MaxValue;
        foreach (GameObject spawnPoint in foundObjects)
        {
            float distance = Vector3.Distance(player.transform.position, spawnPoint.transform.position);
            if (distance < closestDistance && distance > minSpacingDist)
            {
                closestSpawnPoint = spawnPoint;
                closestDistance = distance;
            }
        }

        // If the closest gameobject is within the specified distance, instantiate the prefab
        if (closestSpawnPoint != null && closestDistance <= spawnDistance)
        {
            newCar = Instantiate(prefabToSpawn, closestSpawnPoint.transform.position, Quaternion.identity);
        }
    }

    public void AltEnableAtSpot()
    {
        // Find the gameobject in the list that is closest to the player
        GameObject closestSpawnPoint = null;
        float closestDistance = float.MaxValue;
        foreach (GameObject spawnPoint in foundObjects)
        {
            float distance = Vector3.Distance(player.transform.position, spawnPoint.transform.position);
            if (distance < closestDistance)
            {
                closestSpawnPoint = spawnPoint;
                closestDistance = distance;
            }
        }

        // If the closest gameobject is within the specified distance, instantiate the prefab
        if (closestSpawnPoint != null && closestDistance <= spawnDistance)
        {
            existingCar.transform.SetParent(closestSpawnPoint.transform, false);
            existingCar.SetActive(true);
        }
    }

    public void ForcePlaySound()
    {
        if(newCar == null)
        {
            existingCar.GetComponentInChildren<PlayRandomSound>().DoTimedSpecific(0);
        }
        else
        {
            newCar.GetComponentInChildren<PlayRandomSound>().DoTimedSpecific(0);
        }
    }


}
