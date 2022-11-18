// NAME: Sebastien Yokoyama
// EMAIL: syokoyama2001@gmail.com
// COURSE: CS 425/426
// ASSIGNMENT: Senior Project
// FILE NAME: UILevelElement.cs
/* FILE DESCRIPTION: Class that stores level data for use in UI elements and file I/O. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level : MonoBehaviour
{
    /*---------- Fields ----------*/
    public string name; // Displayed on the load menu
    public string sceneName; // Stores scene name; access scene via SceneManager Methods
    public bool isUnlocked; // Determines if player has access to level

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
