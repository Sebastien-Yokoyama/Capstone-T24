// NAME: Cody Jackson
// EMAIL: codyj@nevada.unr.edu
// COURSE: CS 425/426
// ASSIGNMENT: Senior Project
// FILE NAME: SimpleFadeText.cs
/* FILE DESCRIPTION: When called, plays a fade in animation to the
 * text object it is attached to.*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFadeText : MonoBehaviour
{
    public Animator anim;
    public bool isVisible;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeIn()
    {
        isVisible = true;
        anim.SetBool("isVisible", true);
    }

    public void FadeInAtTime(float time)
    {
        StartCoroutine(FadeInTime(time));
    }

    IEnumerator FadeInTime(float time)
    {
        yield return new WaitForSeconds(time);

        FadeIn();
    }
}
