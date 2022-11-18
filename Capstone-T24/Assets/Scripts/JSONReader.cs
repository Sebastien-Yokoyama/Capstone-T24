// NAME: Sebastien Yokoyama
// EMAIL: syokoyama2001@gmail.com
// COURSE: CS 425/426
// ASSIGNMENT: Senior Project
// FILE NAME: JSONReader.cs
/* FILE DESCRIPTION: Reads the player's saved data. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public TextAsset textJSON;


    [System.Serializable]
    public class LevelList
    {
        public List<Level> level;
    }


    // Start is called before the first frame update
    void Start()
    {
        ReadFile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadFile()
    {
        MainMenuMgr.inst.levels = JsonUtility.FromJson<LevelList>(textJSON.text).level;
    }
}
