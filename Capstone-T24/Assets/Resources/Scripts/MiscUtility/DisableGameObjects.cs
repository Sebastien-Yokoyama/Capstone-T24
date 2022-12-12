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
