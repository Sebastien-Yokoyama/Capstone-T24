// NAME: Sebastien Yokoyama
// EMAIL: syokoyama2001@gmail.com
// COURSE: CS 425/426
// ASSIGNMENT: Senior Project
// FILE NAME: DataMgr.cs
/* FILE DESCRIPTION: Manages all the game data rules. */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMgr : MonoBehaviour
{
    /*---------- Awake ----------*/
    // Static Instance of DataMgr for global usage
    public static DataMgr inst;
    private void Awake()
    {
        inst = this;
    }


    // Fields 
    private iDataService DataService = new JsonDataService();   // Class that provides methods for reading/writing 

    public List<Level> levelList;   // List that stores level data for the JSON file


    // Methods
    // Writes and saves level data to the JSON file
    public void SerializeJson()
    {
        if (DataService.SaveData("/level-data.json", levelList))
        {
            Debug.Log("Data saved");
        }
        else
        {
            Debug.LogError("Could not save file.");
        }
    }

    /*
     Reads and saves level data from the JSON file.
    If the file does not exist, the levelList will not be initialized.
        In this case, the levelList will copy the level data provided in the MainMenuMgr,
        where the data is initialized in the Unity Editor Inspection Window.
     */
    public void DeserializeJson()
    {
        try
        {
            levelList = DataService.LoadData<List<Level>>("/level-data.json");
        }
        catch(Exception e)
        {
            Debug.LogError($"Could not read file.");
        }
    }
}
