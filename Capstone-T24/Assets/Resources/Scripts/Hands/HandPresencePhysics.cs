/*
 * Originally developed by: Valem Tutorials
 * Modified  by: Cody Jackson
 * Video: https://www.youtube.com/watch?v=CfzO6jvLY-w
 * File Name: HandPresencePhysics.cs
 * File Description: Gives the VR hands collision and basic physics interactions.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPresencePhysics : MonoBehaviour
{

    public Transform target;
    private Rigidbody rb;

    public Renderer nonPhysicalHand;
    public float showNonPhysicalHandDistance = 0.05f;

    private Collider[] handColliders;
    private bool isGrabbed = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        handColliders = GetComponentsInChildren<Collider>();
    }

    public void EnableHandCollider()
    {
        if (!isGrabbed)
        {
            foreach (var item in handColliders)
            {
                item.enabled = true;
            }
        }
    }

    public void EnableColliderDelay(float delay)
    {
        Invoke(nameof(EnableHandCollider), delay);
        isGrabbed = false;
    }

    public void DisableHandCollider()
    {
        foreach (var item in handColliders)
        {
            item.enabled = false;
            isGrabbed = true;
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if(distance > showNonPhysicalHandDistance)
        {
            nonPhysicalHand.enabled = true;
        }
        else
        {
            nonPhysicalHand.enabled = false;
        }
    }


    void FixedUpdate()
    {
        // Position
        rb.velocity = (target.position - transform.position) / Time.fixedDeltaTime;

        // Rotation
        Quaternion rotationDifference = target.rotation * Quaternion.Inverse(transform.rotation);
        rotationDifference.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);

        Vector3 rotationDifferenceInDegree = angleInDegree * rotationAxis;

        rb.angularVelocity = (rotationDifferenceInDegree * Mathf.Deg2Rad / Time.fixedDeltaTime);
    }
}
