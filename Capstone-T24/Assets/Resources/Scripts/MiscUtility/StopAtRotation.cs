using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple script to stop something to be able to rotate at a certain degree.
/// </summary>
public class StopAtRotation : MonoBehaviour
{
    public Rigidbody target;
    public float stopDegree;
    public float reportedDegree;
    public bool disabled = false;
    public string targetCoord;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (disabled)
        {
            return;
        }

        switch (targetCoord)
        {
            case "x":
                reportedDegree = this.transform.localRotation.x * 100;
                break;
            case "y":
                reportedDegree = this.transform.localRotation.y * 100;
                break;
            case "z":
                reportedDegree = this.transform.localRotation.z * 100;
                break;

            default:

                break;
        }

        if(reportedDegree >= stopDegree)
        {
            target.isKinematic = true;
            target.useGravity = false;
            disabled = true;
        }
    }
}
