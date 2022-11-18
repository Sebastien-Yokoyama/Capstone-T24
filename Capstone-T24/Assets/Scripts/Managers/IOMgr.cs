// NAME: Sebastien Yokoyama
// EMAIL: syokoyama2001@gmail.com
// COURSE: CS 425/426
// ASSIGNMENT: Senior Project
// FILE NAME: IOMgr.cs
/* FILE DESCRIPTION: Manages all the file I/O in the application. File I/O is used for saving player progress. */

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class IOMgr : MonoBehaviour
{
    /*---------- Fields ----------*/
    public string fileName = Application.persistentDataPath + "/gamedata.json";

    /*---------- Methods ----------*/
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    // Read Save File
    public static bool CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<bool>(jsonString);
    }


    // Write Save File

}
