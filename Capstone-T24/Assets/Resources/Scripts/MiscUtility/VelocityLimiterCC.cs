// NAME: Cody Jackson
// EMAIL: codyj@nevada.unr.edu
// COURSE: CS 425/426
// ASSIGNMENT: Senior Project
// FILE NAME: VelocityLimiterCC.cs
/* FILE DESCRIPTION: Code that DOESN'T limit a character controller's velocity. I hate this. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityLimiterCC : MonoBehaviour
{
    /// <summary>
    /// WHAT THIS SCRIPT DOES:
    /// -This script limits the maximum velocity of a player's character controller as set by the user.
    /// -This can be helpful with portals, as going too fast will break them.
    /// 
    /// HOW TO USE THIS SCRIPT:
    /// -To use this script, simply apply it as a component on an object
    /// that has a character controller.
    /// </summary>

    // The maximum velocity that the character should have
    public float maxVelocity;

    // The character controller component attached to this object
    private CharacterController characterController;

    // The Rigidbody component attached to this object
    private Rigidbody rigidbody;

    // The original direction and magnitude of the character's movement
    private Vector3 originalDirection;
    private float originalMagnitude;

    public Vector3 currentVelocity;

    private void Start()
    {
        // Get the character controller component
        characterController = GetComponent<CharacterController>();

        rigidbody = GetComponent<Rigidbody>();

        // Store the original direction and magnitude of the character's movement
        originalDirection = characterController.velocity.normalized;
        originalMagnitude = characterController.velocity.magnitude;
    }

    private void Update()
    {
        currentVelocity = characterController.velocity;

        // Calculate the current magnitude of the character's movement
        float magnitude = characterController.velocity.magnitude;

        // If the magnitude exceeds the maximum velocity
        if (magnitude > maxVelocity)
        {
            // Calculate the new magnitude based on the maximum velocity and the original magnitude
            float newMagnitude = originalMagnitude * (maxVelocity / magnitude);

            // Calculate the new velocity for the character controller, preserving the y-velocity
            Vector3 newVelocity = characterController.velocity;
            newVelocity.y = originalDirection.y * newMagnitude;
            newVelocity = Vector3.ClampMagnitude(newVelocity, maxVelocity);

            // Calculate the force needed to slow down the character
            Vector3 force = (characterController.velocity - newVelocity) * rigidbody.mass;

            // Apply the force to the Rigidbody
            rigidbody.AddForce(force);
        }
    }
}