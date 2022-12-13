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

        timedFromStart.Invoke();
    }
}
