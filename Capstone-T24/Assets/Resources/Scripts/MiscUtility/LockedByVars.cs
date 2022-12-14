// NAME: Cody Jackson
// EMAIL: codyj@nevada.unr.edu
// COURSE: CS 425/426
// ASSIGNMENT: Senior Project
// FILE NAME: LockedByVars.cs
/* FILE DESCRIPTION: Simple "lock" that relies on bools to be flipped to be
 * unlocked, then triggers a UnityEvent. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LockedByVars : MonoBehaviour
{
    public bool lock1 = false;
    public bool lock2 = false;
    public bool lock3 = false;

    public UnityEvent unlockEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lock1 && lock2 && lock3)
        {
            unlockEvent.Invoke();
        }
    }

    public void Unlock1()
    {
        lock1 = true;
    }
    public void Unlock2()
    {
        lock2 = true;
    }
    public void Unlock3()
    {
        lock3 = true;
    }
}
