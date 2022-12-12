using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityLimiter : MonoBehaviour
{
    /// <summary>
    /// WHAT THIS SCRIPT DOES:
    /// -This script limits the maximum velocity of a rigidbody as set by the user.
    /// -This can be helpful with portals, as going too fast will break them.
    /// 
    /// HOW TO USE THIS SCRIPT:
    /// -To use this script, simply apply it as a component on an object
    /// that has a rigidbody.
    /// </summary>


    public float maxVelocity; // Maximum velocity the rigidbody can reach

    private Rigidbody rb; // Reference to the rigidbody

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the rigidbody component
    }

    private void FixedUpdate()
    {
        // Limit the velocity of the rigidbody if it exceeds the maximum velocity
        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }
    }
}
