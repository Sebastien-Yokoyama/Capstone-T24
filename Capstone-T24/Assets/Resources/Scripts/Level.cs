// NAME: Sebastien Yokoyama
// EMAIL: syokoyama2001@gmail.com
// COURSE: CS 425/426
// ASSIGNMENT: Senior Project
// FILE NAME: Level.cs
/* FILE DESCRIPTION: Class that stores level data for use in UI elements and file I/O. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    /*---------- Fields ----------*/
    public string name; // Displayed on the load menu
    public string sceneName; // Stores scene name; used to access scenes via SceneManager Methods
    public bool isUnlocked; // Determines if player has access to level


    /*---------- Methods ----------*/
    // Parameterized Constructor
    public Level(string newName, string newSceneName, bool newIsUnlocked)
    {
        name = newName;
        sceneName = newSceneName;
        isUnlocked = newIsUnlocked;
    }
}
