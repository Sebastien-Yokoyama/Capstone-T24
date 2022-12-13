using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnlyOnce : MonoBehaviour
{
    public AudioSource source;

    public bool locked = false;
    public bool doOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        source = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound()
    {
        if (locked)
        {
            return;
        }

        source.PlayOneShot(source.clip);
        Lock();
    }

    public void Unlock()
    {
        locked = false;
    }

    public void Lock()
    {
        locked = true;
    }

    public void UnlockAfterTime(float time)
    {
        if (!doOnce)
        {
            doOnce = true;
            StartCoroutine(UnlockedTime(time));
        }
    }

    IEnumerator UnlockedTime(float time)
    {
        yield return new WaitForSeconds(time);

        Unlock();
        doOnce = false;
    }
}
