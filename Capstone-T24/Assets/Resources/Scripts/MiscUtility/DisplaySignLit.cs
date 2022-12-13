using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaySignLit : MonoBehaviour
{

    /// <summary>
    /// Used by the 3 indicators in Lab1. Will turn an emmisive light from off to on after x amount of time.
    /// </summary>

    public Material startMaterial = null;
    public Material endMaterial = null;
    public MeshRenderer meshRend = null;
    private bool inProgress = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallGo(float time)
    {
        if (!inProgress)
        {
            StartCoroutine(flipAfterSeconds(time));
        }
        inProgress = true;
    }

    IEnumerator flipAfterSeconds(float time)
    {
        yield return new WaitForSeconds(time);

        meshRend.material = endMaterial;
    }
}
