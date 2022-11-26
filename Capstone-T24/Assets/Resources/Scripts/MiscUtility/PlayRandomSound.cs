using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomSound : MonoBehaviour
{
    public List<AudioClip> SoundClips = new List<AudioClip>();
    public AudioClip specificSound = null;
    public AudioSource source;

    private bool doOnce = false;
    private bool doOnce2 = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayClipRandom()
    {
        int len = SoundClips.Count - 1; // because 0 is included
        int random = UnityEngine.Random.Range(0, len);

        source.PlayOneShot(SoundClips[random]);
    }

    public void DoTimedRandom(float time)
    {
        if (!doOnce)
        {
            StartCoroutine(TimedRandom(time));
        }
        doOnce = true;
    }

    IEnumerator TimedRandom(float time)
    {
        yield return new WaitForSeconds(time);

        PlayClipRandom();
    }

    public void DoTimedSpecific(float time)
    {
        if (!doOnce2)
        {
            StartCoroutine(TimedRandom(time));
        }
        doOnce2 = true;
    }

    IEnumerator TimedSpecific(float time)
    {
        yield return new WaitForSeconds(time);

        source.PlayOneShot(specificSound);
    }


}
