// NAME: Cody Jackson
// EMAIL: codyj@nevada.unr.edu
// COURSE: CS 425/426
// ASSIGNMENT: Senior Project
// FILE NAME: HintMgr.cs
/* FILE DESCRIPTION: Manages the hints system. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintMgr : MonoBehaviour
{
    public static HintMgr inst;
    public void Awake()
    {
        inst = this;
    }

    public float levelTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerable LevelClock()
    {
        yield return new WaitForSeconds(levelTime);
    }

    void ProvideHint(int detail, int level)
    {

    }
}
