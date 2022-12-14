// NAME: Cody Jackson
// EMAIL: codyj@nevada.unr.edu
// COURSE: CS 425/426
// ASSIGNMENT: Senior Project
// FILE NAME: GenericTrigger.cs
/* FILE DESCRIPTION: A script which can be applied to a Box Collider
 * set as "Trigger" which will invoke an event when an object
 with the specified tag enters/exits its space. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenericTrigger : MonoBehaviour
{
    //[Tooltip("The ID of the event that this trigger will cause when activated.")]
    //public int eventToTrigger;

    public string targetTag = "Player";

    public UnityEvent onTagEnter;
    public UnityEvent onTagExit;

    void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider has the target tag.
        if (other.tag == targetTag)
        {
            // If it does, invoke the Unity Event.
            onTagEnter.Invoke();
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the exiting collider has the target tag.
        if (other.tag == targetTag)
        {
            // If it does, invoke the Unity Event.
            onTagExit.Invoke();
        }
    }

}
