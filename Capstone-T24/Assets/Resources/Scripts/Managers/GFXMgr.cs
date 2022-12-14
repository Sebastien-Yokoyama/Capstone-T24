// NAME: Cody Jackson
// EMAIL: codyj@nevada.unr.edu
// COURSE: CS 425/426
// ASSIGNMENT: Senior Project
// FILE NAME: GFXMgr.cs
/* FILE DESCRIPTION: Manages Special Effects. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GFXMgr : MonoBehaviour
{

    public static GFXMgr inst;
    public void Awake()
    {
        inst = this;
    }

    public List<GameObject> vfx = new List<GameObject>();
    public List<GameObject> activeEffects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateEffectHere(int type, Vector3 location, GameObject parent = null)
    {

    }
}
