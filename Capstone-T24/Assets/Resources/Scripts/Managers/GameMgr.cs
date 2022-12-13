// NAME: Sebastien Yokoyama
// EMAIL: syokoyama2001@gmail.com
// COURSE: CS 425/426
// ASSIGNMENT: Senior Project
// FILE NAME: GameMgr.cs
/* FILE DESCRIPTION: Manages all the game rules. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    /// <summary>
    /// Should the Tunneling Vignette be active? 
    /// </summary>
    public bool usingVignette = false;
    /// <summary>
    /// Completely disable/enable movement.
    /// </summary>
    public bool disabledMovement = false;
    /// <summary>
    /// Hand that the user teleports with, has ray components in it.
    /// </summary>
    public GameObject teleportHand;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Easy quit for debug purposes
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Game is quitting");  // Test msg
        }
    }

    /// <summary>
    /// Called when the player completes the current level
    /// </summary>
    public void CompleteCurrentLevel()
    {
        // Used to load next level; will load main menu by default
        string nextLevelName = "_MainMenu";

        // Load data from file
        DataMgr.inst.DeserializeJson();

        // Overwrite data
        for(int i = 0; i < DataMgr.inst.levelList.Count; i++)
        {
            // Unlock next level, if it is not the last level in the game
            if ((DataMgr.inst.levelList[i].sceneName == SceneManager.GetActiveScene().name) && (i + 1 < DataMgr.inst.levelList.Count))
            {
                DataMgr.inst.levelList[i + 1].isUnlocked = true;
                nextLevelName = DataMgr.inst.levelList[i + 1].sceneName;    // If there are more levels, load those instead of main menu
            }
        }

        // Save data to file
        DataMgr.inst.SerializeJson();

        // Load the next level
       SceneManager.LoadSceneAsync(nextLevelName);
    }

    /// <summary>
    /// Changes which method of movement the player will use. (bool)
    /// </summary>
    public void ChangeMovementMethod()
    {
        if (disabledMovement) // Maybe change this later
        {
            return;
        }

        movementMode = !movementMode;

        if (movementMode) // Teleport Movement
        {
            // Disable Continuous Movement Provider
            XROrigin.GetComponent<ContinuousMoveProviderBase>().enabled = false;
            // Enable the Teleport Movement Provider
            XROrigin.GetComponent<TeleportationProvider>().enabled = true;
            XROrigin.GetComponent<ActivateTeleportationRay>().enabled = true;
            teleportHand.SetActive(true);
            if (usingVignette)
                // Apply delay so vignette works properly
                XROrigin.GetComponent<TeleportationProvider>().delayTime = 0.3f;
        }
        else // Continuous Movement
        {
            // Enable Continuous Movement Provider
            XROrigin.GetComponent<ContinuousMoveProviderBase>().enabled = true;
            // Disable the Teleport Movement Provider
            XROrigin.GetComponent<TeleportationProvider>().enabled = false;
            XROrigin.GetComponent<ActivateTeleportationRay>().enabled = false;
            teleportHand.SetActive(false);
            if (usingVignette)
                // Reset delay
                XROrigin.GetComponent<TeleportationProvider>().delayTime = 0.0f;
        }
    }

    /// <summary>
    /// Toggles if the Tunneling Vignette is on or off.
    /// </summary>
    public void ChangeVignetteUsage()
    {
        usingVignette = !usingVignette;

        // May not work for every provider, given there are more than one.
        XROrigin.GetComponentInChildren<TunnelingVignetteController>().GetComponent<LocomotionVignetteProvider>().enabled = usingVignette;
    }

    /// <summary>
    /// Disables all player movement (providers).
    /// </summary>
    public void DisableAllMovement(bool includeTurning)
    {
        XROrigin.GetComponent<ContinuousMoveProviderBase>().enabled = false;
        XROrigin.GetComponent<TeleportationProvider>().enabled = false;
        XROrigin.GetComponent<ActivateTeleportationRay>().enabled = false;
        teleportHand.SetActive(false);

        if (includeTurning)
        {
            XROrigin.GetComponent<ContinuousTurnProviderBase>().enabled = false;
            XROrigin.GetComponent<SnapTurnProviderBase>().enabled = false;
        }
    }

    public void EnableMovement()
    {
        if (movementMode) // Teleport Movement
        {
            XROrigin.GetComponent<ContinuousMoveProviderBase>().enabled = true;
            XROrigin.GetComponent<ActivateTeleportationRay>().enabled = true;
            teleportHand.SetActive(true);
        }
        else // Continuous Movement
        {
            XROrigin.GetComponent<TeleportationProvider>().enabled = true;
        }

        // Turning
        XROrigin.GetComponent<ContinuousTurnProviderBase>().enabled = true;
        XROrigin.GetComponent<SnapTurnProviderBase>().enabled = true;
    }
}
