// NAME: Cody Jackson
// EMAIL: codyj@nevada.unr.edu
// COURSE: CS 425/426
// ASSIGNMENT: Senior Project
// FILE NAME: SoundMgr.cs
/* FILE DESCRIPTION: Manages major in game sounds / ambiences / music. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour
{
    public static SoundMgr inst;
    public void Awake()
    {
        inst = this;
    }

    public AudioSource aSource;

    public AudioClip[] audioClips = new AudioClip[30];
    public AudioClip[] ambientClips = new AudioClip[5];

    public AudioSource globalA; // Global sounds
    public AudioSource globalB; // Ambient/Music

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGlobalSound(int id)
    {
        globalA.PlayOneShot(audioClips[id]);
    }

    public void PlayAmbientAudio(int id)
    {
        //this.GetComponent<AudioSource>().loop = true;
        globalB.PlayOneShot(ambientClips[id]);
        //global++; //?
    }
}
