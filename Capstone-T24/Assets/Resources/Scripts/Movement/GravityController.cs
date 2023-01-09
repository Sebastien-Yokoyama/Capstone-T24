// NAME: Cody Jackson
// EMAIL: codyj@nevada.unr.edu
// COURSE: CS 425/426
// ASSIGNMENT: Senior Project
// FILE NAME: GravityController.cs
/* FILE DESCRIPTION: Used to change the direction of gravity and rotate the player appropriately. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    /*
     * ~ The Cube ~
           +--------+
          /        /|
         / Top1   / |
        +--------+ S|
        |S Back3 |id|
        |i Front4|e5+
        |de6     | /
        | Bottom2|/
        +--------+

            
           (y)
            *
            |
            |
            + -- -- * (z)
           /
          /
         *
       (x)

     */

    public GameObject player;
    [Tooltip("Speed at which the player will rotate. Be careful with this.")]
    public float rotateSpeed = 10f;

    // The target rotation that the player should rotate towards (as a Vector3)
    public Vector3 targetRotation;
    // The flag that determines whether the player should rotate towards the target rotation
    public bool rotateFlag = false;


    // Update is called once per frame
    void Update()
    {
        if (rotateFlag)
        {
            // Calculate the current rotation of the player
            Quaternion currentRotation = player.transform.localRotation;

            // Convert the target rotation from a Vector3 to a Quaternion
            Quaternion targetRotationQuat = Quaternion.Euler(targetRotation);

            // Calculate the difference between the current rotation and the target rotation
            Quaternion rotationDifference = targetRotationQuat * Quaternion.Inverse(currentRotation);

            // Calculate the angle of rotation difference
            float angle;
            Vector3 axis;
            rotationDifference.ToAngleAxis(out angle, out axis);

            // Rotate the player towards the target rotation along the specified axis
            if (angle > 0)
            {
                float rotateAmount = rotateSpeed * Time.deltaTime;

                // Rotate the player by a maximum of the remaining angle
                if (rotateAmount > angle)
                {
                    rotateAmount = angle;
                }

                player.transform.Rotate(targetRotation, rotateAmount, Space.Self);
            }
            else
            {
                // Rotation is complete, unset the flag
                rotateFlag = false;
            }
        }
    }

    public void UseNormalGravity() // 1
    {
        Vector3 desired = new Vector3(0, 9.8f, 0);

        Physics.gravity = desired;
        targetRotation = desired;

        rotateFlag = true;
    }

    public void InvertGravity() // 2
    {
        Vector3 desired = new Vector3(0, -9.8f, 0);

        Physics.gravity = desired;
        targetRotation = desired;

        rotateFlag = true;
    }

    public void UseBackGrav() // 3
    {
        Vector3 desired = new Vector3(9.8f, 0, 0);

        Physics.gravity = desired;
        targetRotation = desired;

        rotateFlag = true;
    }

    public void UseFrontGrav() // 4
    {
        Vector3 desired = new Vector3(-9.8f, 0, 0);

        Physics.gravity = desired;
        targetRotation = desired;

        rotateFlag = true;
    }

    public void UseRSideGrav() // 5
    {
        Vector3 desired = new Vector3(0, 0, -9.8f);

        Physics.gravity = desired;
        targetRotation = desired;

        rotateFlag = true;
    }

    public void UseLSideGrav() // 6
    {
        Vector3 desired = new Vector3(0, 0, 9.8f);

        Physics.gravity = desired;
        targetRotation = desired;

        rotateFlag = true;
    }
}
