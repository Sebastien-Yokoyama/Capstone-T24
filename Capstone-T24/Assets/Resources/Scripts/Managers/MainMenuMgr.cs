// NAME: Sebastien Yokoyama
// EMAIL: syokoyama2001@gmail.com
// COURSE: CS 425/426
// ASSIGNMENT: Senior Project
// FILE NAME: MainMenuMgr.cs
/* FILE DESCRIPTION: Manages all the main menu UI elements in the game. */

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
    public List<Level> levels = new List<Level>();    // Stores prefabs of Level that have name, unlock status, etc.
    public List<Sprite> levelThumbnails = new List<Sprite>();   // Stores thumbnails of each level
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
        // Load data from file
        //JSONReader.inst.ReadFile();
        DataMgr.inst.DeserializeJson();
        if (DataMgr.inst.levelList.Count > 0) { // If JSON file exists, overwrite level data
            levels = DataMgr.inst.levelList;
        }
        else {  // Otherwise, create JSON file using default data
            CreateJSON();
        }

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
        selectedLevelThumbnail.sprite = levelThumbnails[index];
        lockOverlay.gameObject.SetActive(!levels[index].isUnlocked);
        startButton.gameObject.SetActive(levels[index].isUnlocked);
        lockText.gameObject.SetActive(!levels[index].isUnlocked);
    }
    
    // Helper method that creates the level data JSON file if it doesn't exist
    void CreateJSON()
    {
        /*
         Since the file does not exist, the levelList in DataMgr will not have any initialized values.
        Therefore, we can use the data from this manager, where it has been initialized with default values in the Unity Editor Inspection Window.
        After saving the default data, we can now create the JSON file for later use.
         */
        DataMgr.inst.levelList = levels;
        DataMgr.inst.SerializeJson();
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
    public void LoadLevel()
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
