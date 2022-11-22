// NAME: Sebastien Yokoyama
// EMAIL: syokoyama2001@gmail.com
// COURSE: CS 425/426
// ASSIGNMENT: Senior Project
// FILE NAME: JSONReader.cs
/* FILE DESCRIPTION: Reads the player's saved data. */

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    /*---------- Awake ----------*/
    // Static Instance of MainMenuMgr for global usage
    public static JSONReader inst;
    private void Awake()
    {
        inst = this;
    }


    public TextAsset textJSON;
    public string dataString;


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


    public void ReadFile()
    {
        MainMenuMgr.inst.levels = JsonUtility.FromJson<LevelList>(textJSON.text).level;
    }

    public void WriteFile()
    {
        LevelList myLevelList = new LevelList();
        myLevelList.level = MainMenuMgr.inst.levels;
        string output = JsonUtility.ToJson(myLevelList);

        //File.WriteAllText(Application.dataPath + "/appdata.txt", output);
        File.WriteAllText("Assets/Data/appdata.txt", output);
    }
}
