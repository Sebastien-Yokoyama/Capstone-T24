// NAME: Cody Jackson
// EMAIL: codyj@nevada.unr.edu
// COURSE: CS 425/426
// ASSIGNMENT: Senior Project
// FILE NAME: DisableGameObjects.cs
/* FILE DESCRIPTION: When called can disable all gameObjects in it's list. Can also re-enable them. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGameObjects : MonoBehaviour
{
    public GameObject[] gameObjList;

    public void DisableGameObjectsInArray()
    {
        // Iterate through the array and disable each GameObject
        foreach (GameObject gameObject in gameObjList)
        {
            gameObject.SetActive(false);
        }
    }

    public void ReEnableGameObjects()
    {
        foreach (GameObject gameObject in gameObjList)
        {
            gameObject.SetActive(true);
        }
    }
}
