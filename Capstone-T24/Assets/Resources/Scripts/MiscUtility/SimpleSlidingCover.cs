// NAME: Cody Jackson
// EMAIL: codyj@nevada.unr.edu
// COURSE: CS 425/426
// ASSIGNMENT: Senior Project
// FILE NAME: SimpleSlidingCover.cs
/* FILE DESCRIPTION: Used by the glass cover in Lab1, when called
 * can do an animation that opens/closes it. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSlidingCover : MonoBehaviour
{
    public bool isOpen = false;
    public bool doOnce = false;
    private bool onlyOnce = false;
    public Animator anim;

    [Tooltip("UNUSED: ???")]
    public bool specialValidate = false;
    [Tooltip("Do certain flags need to be set so that this will only open after those flags are set? Int value = # of flags (max 2).")]
    public int validation = 0;
    public bool valid1 = false;
    public bool valid2 = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlipAtTime(float time)
    {
        if(validation == 0)
        {
            if (!doOnce)
            {
                StartCoroutine(FlipTime(time));
            }
            doOnce = true;
        }
        else if(validation == 1)
        {
            if (!doOnce && valid1)
            {
                StartCoroutine(FlipTime(time));
            }
            doOnce = true;
        }
        else if(validation == 2)
        {
            if (!doOnce && valid1 && valid2)
            {
                StartCoroutine(FlipTime(time));
            }
            doOnce = true;
        }
    }

    public void ForceOpen(bool oneTime)
    {
        if(oneTime && !onlyOnce)
        {
            isOpen = true;
            anim.SetBool("isOpen", true);
            onlyOnce = true;
        }
        else if (!oneTime)
        {
            isOpen = true;
            anim.SetBool("isOpen", true);
        }
    }

    public void ForceClosed()
    {
        isOpen = false;
        anim.SetBool("isOpen", false);
    }

    IEnumerator FlipTime(float time)
    {
        yield return new WaitForSeconds(time);

        isOpen = !isOpen;

        if (isOpen)
        {
            anim.SetBool("isOpen", true);
        }
        else
        {
            anim.SetBool("isOpen", false);
        }
    }

    public void Validate1()
    {
        valid1 = true;
    }

    public void Validate2()
    {
        valid2 = true;
    }
}
