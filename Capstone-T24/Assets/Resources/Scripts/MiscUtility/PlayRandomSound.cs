using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomSound : MonoBehaviour
{
    public List<AudioClip> SoundClips = new List<AudioClip>();
    public AudioSource source;

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
        int random = Random.Range(0, len);

        source.PlayOneShot(SoundClips[random]);
    }
}
