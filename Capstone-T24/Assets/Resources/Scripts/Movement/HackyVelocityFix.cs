using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackyVelocityFix : MonoBehaviour
{
    /// <summary>
    /// This is a hacky fix because SOMEBODY decided that the "velocity" value on the character controller should be "read-only". THANKS FOR THAT.
    /// </summary>

    // The y-velocity threshold at which the platform will be spawned
    public float velocityThreshold;

    // The platform prefab that will be spawned
    public GameObject platformPrefab;

    // The spawned platform GameObject
    private GameObject spawnedPlatform;

    public float yVelocity;

    // The character controller component attached to this object
    private CharacterController characterController;

    private void Start()
    {
        // Get the character controller component
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current y-velocity of the player
        yVelocity = characterController.velocity.y;

        // Check if the y-velocity is greater than the threshold
        if (yVelocity > velocityThreshold)
        {
            
            // Spawn the platform if it doesn't already exist
            if (spawnedPlatform == null)
            {
                spawnedPlatform = Instantiate(platformPrefab, transform.position, Quaternion.identity);
            }
            
        }
        else
        {
            // Destroy the platform if it exists and the y-velocity is low
            if (spawnedPlatform != null)
            {
                Destroy(spawnedPlatform);
            }
        }
    }
}
