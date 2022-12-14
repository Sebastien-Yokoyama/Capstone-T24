// NAME: Cody Jackson
// EMAIL: codyj@nevada.unr.edu
// COURSE: CS 425/426
// ASSIGNMENT: Senior Project
// FILE NAME: ColorFlip.cs
/* FILE DESCRIPTION: When called swaps an attached objects color. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFlip : MonoBehaviour
{
    // The material to change to when needed
    public Material newMaterial;

    // The object's current material
    private Material oldMaterial;

    // The object's MeshRenderer component
    private MeshRenderer meshRenderer;

    void Start()
    {
        // Get the MeshRenderer component and store it in a variable
        meshRenderer = GetComponent<MeshRenderer>();

        // Store the object's current material in a variable
        oldMaterial = meshRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColor()
    {
        meshRenderer.material = newMaterial;
    }

    public void RevertColor()
    {
        meshRenderer.material = oldMaterial;
    }
}
