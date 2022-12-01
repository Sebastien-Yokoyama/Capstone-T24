// NAME: Sebastien Yokoyama
// EMAIL: syokoyama2001@gmail.com
// COURSE: CS 425/426
// ASSIGNMENT: Senior Project
// FILE NAME: GameMgr.cs
/* FILE DESCRIPTION: Manages all the game rules. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameMgr : MonoBehaviour
{
    /*---------- Awake ----------*/
    // Static Instance of MainMenuMgr for global usage
    public static GameMgr inst;
    private void Awake()
    {
        inst = this;
    }

    // Variables
    public GameObject XROrigin;
    /// <summary>
    /// Defines which movement method is currently being used.
    /// Continuous Movement = False
    /// Teleport Movement = True
    /// </summary>
    public bool movementMode = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Called when the player completes the current level
    /// </summary>
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

    /// <summary>
    /// Changes which method of movement the player will use. (bool)
    /// </summary>
    public void ChangeMovementMethod()
    {
        movementMode = !movementMode;

        if (movementMode) // Teleport Movement
        {
            // Disable Continuous Movement Provider
            XROrigin.GetComponent<ContinuousMoveProviderBase>().enabled = false;
            // Enable the Teleport Movement Provider
            XROrigin.GetComponent<TeleportationProvider>().enabled = true;
        }
        else // Continuous Movement
        {
            // Enable Continuous Movement Provider
            XROrigin.GetComponent<ContinuousMoveProviderBase>().enabled = true;
            // Disable the Teleport Movement Provider
            XROrigin.GetComponent<TeleportationProvider>().enabled = false;
        }
    }
}
