using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerAfterTime : MonoBehaviour
{
    // The time the object must spend inside the trigger before the event is activated. (Default of 5s)
    public float timeToActivate = 5.0f;

    // The "Tag" of the object that must be inside the trigger to activate the event. (Default of Player)
    public string targetTag = "Player";

    // The event to activate.
    public UnityEvent eventToActivate;

    // The object currently inside the trigger.
    private GameObject currentObject;

    // The time the current object has spent inside the trigger.
    private float timeInsideTrigger = 0.0f;

    // This function is called when another object enters the trigger.
    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object has the correct "Tag".
        if (other.gameObject.tag == targetTag)
        {
            // Set the current object to the entering object.
            currentObject = other.gameObject;
        }
    }

    // This function is called when another object stays inside the trigger.
    private void OnTriggerStay(Collider other)
    {
        // Check if the current object is still inside the trigger.
        if (currentObject == other.gameObject)
        {
            // Increment the time the current object has spent inside the trigger.
            timeInsideTrigger += Time.deltaTime;

            // Check if the current object has spent enough time inside the trigger to activate the event.
            if (timeInsideTrigger >= timeToActivate)
            {
                // Activate the event.
                eventToActivate.Invoke();
            }
        }
    }

    // This function is called when another object exits the trigger.
    private void OnTriggerExit(Collider other)
    {
        // Check if the exiting object is the current object.
        if (currentObject == other.gameObject)
        {
            // Reset the current object and the time spent inside the trigger.
            currentObject = null;
            timeInsideTrigger = 0.0f;
        }
    }
}
