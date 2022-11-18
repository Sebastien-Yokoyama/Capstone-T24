// NAME: Sebastien Yokoyama
// EMAIL: syokoyama2001@gmail.com
// COURSE: CS 425/426
// ASSIGNMENT: Senior Project
// FILE NAME: MainMenuMgr.cs
/* FILE DESCRIPTION: Manages all the main menu elements in the game. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMgr : MonoBehaviour
{
    /*---------- Awake ----------*/
    // Static Instance of MainMenuMgr for global usage
    public static MainMenuMgr inst;
    private void Awake()
    {
        inst = this;
    }


    /*---------- Fields ----------*/


    /*---------- Methods ----------*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Starts the game from the beginning
    public void StartGame()
    {

    }

    // Quits the application
    public void QuitGame()
    {
        Application.Quit(); // Quit application
        Debug.Log("Game is quitting");  // Test msg
    }
}
