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

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider has the target tag.
        if (other.tag == targetTag)
        {
            // If it does, invoke the Unity Event.
            onTagEnter.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the exiting collider has the target tag.
        if (other.tag == targetTag)
        {
            // If it does, invoke the Unity Event.
            onTagExit.Invoke();
        }
    }

}
