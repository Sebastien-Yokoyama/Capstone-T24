using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UILevelElement : MonoBehaviour
{
    /*---------- Fields ----------*/
    // Fields for Load Menu
    public string name; // Displayed on the load menu
    public Sprite thumbnail;   // Displayed on the load menu

    public bool isUnlocked; // Determines if player has access to level

    public string sceneName; // Stores scene name; access scene via SceneManager Methods

    /*---------- Methods ----------*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
