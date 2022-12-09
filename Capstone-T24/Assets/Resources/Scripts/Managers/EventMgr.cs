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

    // Start is called before the first frame update
    void Start()
    {
        
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
}
