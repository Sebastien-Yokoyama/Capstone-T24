// NAME: Sebastien Yokoyama
// EMAIL: syokoyama2001@gmail.com
// COURSE: CS 425/426
// ASSIGNMENT: Senior Project
// FILE NAME: GameMgr.cs
/* FILE DESCRIPTION: Manages all the game rules. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    /*---------- Awake ----------*/
    // Static Instance of MainMenuMgr for global usage
    public static GameMgr inst;
    private void Awake()
    {
        inst = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Called when the player completes the current level
    public void CompleteCurrentLevel()
    {
        // Check out-of-bounds
        if (MainMenuMgr.inst.selectedLevelIndex < MainMenuMgr.inst.levels.Count)
        {
            // Set next level to be unlocked
            MainMenuMgr.inst.levels[MainMenuMgr.inst.selectedLevelIndex + 1].isUnlocked = true;
        }

        // Save data
        JSONReader.inst.WriteFile();
    }
}
