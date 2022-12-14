// NAME: Cody Jackson
// EMAIL: codyj@nevada.unr.edu
// COURSE: CS 425/426
// ASSIGNMENT: Senior Project
// FILE NAME: EventMgr.cs
/* FILE DESCRIPTION: Handles major in-game events/sequences
 * using UnityEvents. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventMgr : MonoBehaviour
{

    public static EventMgr inst;
    public void Awake()
    {
        inst = this;
    }

    /// <summary>
    /// The event that ends the intro sequence.
    /// </summary>
    public UnityEvent endIntroSequence;

    public UnityEvent timedFromStart;

    public int eventFromStart;
    public float eventFromStartTime;

    // Start is called before the first frame update
    void Start()
    {
        if(eventFromStart != 0)
        {
            StartCoroutine(TimedEventFromStart(eventFromStart, eventFromStartTime));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (startChecking)
        {
            if (!onlyOnce)
            {
                if (mainCamera.GetComponent<IsLookingAt>().isLooking) // Player looking at specific object
                {
                    lookCompleted.Invoke();
                    onlyOnce = true;
                    startChecking = false;
                }
            }
        }
    }

    public void BeginEndIntroSequence(float time)
    {
        StartCoroutine(EndOfIntroSequence(time));
    }

    IEnumerator EndOfIntroSequence(float time)
    {
        yield return new WaitForSeconds(time);

        endIntroSequence.Invoke();
    }

    IEnumerator TimedEventFromStart(int id, float time)
    {

        yield return new WaitForSeconds(time);

        if(id == 1)
        {
            timedFromStart.Invoke();
        }
        else if (id == 2)
        {
            tutorialArrival.Invoke();
        }
    }

    public void SetString(string levelname)
    {
        nextLevel = levelname;
    }

    public string nextLevel = "_MainMenu";

    public void EndSceneAfterTime(float time)
    {
        StartCoroutine(EndSceneTime(time));
    }

    IEnumerator EndSceneTime(float time)
    {
        yield return new WaitForSeconds(time);

        GameMgr.inst.LoadLevelDirect(nextLevel);
    }


    // Tutorial Events

    public UnityEvent tutorialArrival;

    public UnityEvent lookCompleted;

    public UnityEvent moveCompleted;

    public UnityEvent grabCompleted;

    public bool startChecking = false;

    public bool onlyOnce = false;

    public GameObject mainCamera;

    public void BeginCheckAfterTime(float time)
    {
        StartCoroutine(BeginCheckTime(time));
    }

    IEnumerator BeginCheckTime(float time)
    {
        yield return new WaitForSeconds(time);

        startChecking = true;
    }

    public void MoveDoneGo()
    {
        moveCompleted.Invoke();
    }

    public void GrabComplete()
    {
        grabCompleted.Invoke(); 
    }
}
