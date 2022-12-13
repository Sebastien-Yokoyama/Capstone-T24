// NAME: Sebastien Yokoyama
// EMAIL: syokoyama2001@gmail.com
// COURSE: CS 425/426
// ASSIGNMENT: Senior Project
// FILE NAME: JsonDataService.cs
/* FILE DESCRIPTION: Class that offers methods for reading and writing data. */

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class JsonDataService : iDataService
{
    public bool SaveData<T>(string relativePath, List<T> data)
    {
        string path = Application.persistentDataPath + relativePath;

        try
        {
            // Check if data file already exists
            if (File.Exists(path))
            {
                Debug.Log("Data exists. Deleting old file and writing a new one.");

                // Delete data file, if so
                File.Delete(path);
            }
            else
            {
                Debug.Log("Writing file for the first time");
            }

            using FileStream stream = File.Create(path);
            stream.Close();

            File.WriteAllText(path, JsonConvert.SerializeObject(data, Formatting.Indented));

            return true;

        }
        catch (Exception e)
        {
            Debug.LogError($"Unable to save data due to: {e.Message} {e.StackTrace}");

            return false;
        }
    }

    public T LoadData<T>(string relativePath)
    {
        string path = Application.persistentDataPath + relativePath;

        // Check if data file exists
        if (!File.Exists(path))
        {
            Debug.LogError($"Cannot load file at {path}. File does not exist.");

            throw new FileNotFoundException($"{path} does not exist.");
        }

        try
        {
            T data = JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
            return data;
        }
        catch(Exception e)
        {
            Debug.LogError($"Failed to load data due to: {e.Message} {e.StackTrace}");
            throw e;
        }
    }
}
