// NAME: Cody Jackson
// EMAIL: codyj@nevada.unr.edu
// COURSE: CS 425/426
// ASSIGNMENT: Senior Project
// FILE NAME: ActiveTeleportationRay.cs
/* FILE DESCRIPTION: Quick code that enables/disables the visibility of the teleport ray when not in use. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateTeleportationRay : MonoBehaviour
{
    //public GameObject leftTeleportation;
    public GameObject rightTeleportation;

    //public InputActionProperty leftActivate;
    public InputActionProperty rightActivate;

    void Update()
    {
        //leftTeleportation.SetActive(leftActivate.action.ReadValue<float>() > 0.1f);
        rightTeleportation.SetActive(rightActivate.action.ReadValue<float>() > 0.1f);
    }
}
