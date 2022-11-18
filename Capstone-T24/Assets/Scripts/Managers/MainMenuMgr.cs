// NAME: Sebastien Yokoyama
// EMAIL: syokoyama2001@gmail.com
// COURSE: CS 425/426
// ASSIGNMENT: Senior Project
// FILE NAME: MainMenuMgr.cs
/* FILE DESCRIPTION: Manages all the main menu elements in the game. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

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
    // Fields for Managing Load Menu
    [Header("Load Menu")]
    public List<UILevelElement> levels = new List<UILevelElement>();    // Stores prefabs of UILevelElement that have name, thumbnail, etc.
    public int selectedLevelIndex;    // Index of Level currently being displayed

    public TMP_Text selectedLevelName;    // Object that displays level name
    public Image selectedLevelThumbnail;   // Object that displays thumbnail
    public Image lockOverlay;   // Set True when level is locked
    public Button startButton;  // Start Button
    public TMP_Text lockText;   // Displays text that level is locked


    /*---------- Methods ----------*/
    // Start is called before the first frame update
    void Start()
    {
        // Initialize Selected Level to be 0
        selectedLevelIndex = 0;

        // Initialize Data Accordingly
        SetData(selectedLevelIndex);
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    // Helper method that sets data given an index value
    void SetData(int index)
    {
        selectedLevelName.text = levels[index].name;
        selectedLevelThumbnail.sprite = levels[index].thumbnail;
        lockOverlay.gameObject.SetActive(!levels[index].isUnlocked);
        startButton.gameObject.SetActive(levels[index].isUnlocked);
        lockText.gameObject.SetActive(!levels[index].isUnlocked);
    }


    // Starts the game from the beginning
    public void StartGame()
    {
        // Only loads test scene for now
        SceneManager.LoadSceneAsync("TestScene");
    }


    // Displays the next level on the load menu
    public void SelectNextLevel()
    {
        // Iterate to next element
        selectedLevelIndex++;

        // Wrap to beginning if at end of List
        if (selectedLevelIndex >= levels.Count)
        {
            selectedLevelIndex = 0;
        }

        // Update Data
        SetData(selectedLevelIndex);
    }


    // Displays the previous level on the load menu
    public void SelectPreviousLevel()
    {
        // Iterate to previous element
        selectedLevelIndex--;

        // Wrap to end if at beginning of List
        if (selectedLevelIndex < 0)
        {
            selectedLevelIndex = levels.Count - 1;
        }

        // Set and display new data
        SetData(selectedLevelIndex);
    }


    // Loads the level from the List that corresponds to the given index
    public void LoadLevel(int index)
    {
        SceneManager.LoadSceneAsync(levels[selectedLevelIndex].sceneName);
    }


    // Quits the application
    public void QuitGame()
    {
        Application.Quit(); // Quit application
        Debug.Log("Game is quitting");  // Test msg
    }
}
