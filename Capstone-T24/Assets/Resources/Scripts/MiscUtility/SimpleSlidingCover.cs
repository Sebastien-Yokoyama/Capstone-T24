using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSlidingCover : MonoBehaviour
{
    public bool isOpen = false;
    public bool doOnce = false;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlipAtTime(float time)
    {
        if (!doOnce)
        {
            StartCoroutine(FlipTime(time));
        }
        doOnce = true;
    }

    IEnumerator FlipTime(float time)
    {
        yield return new WaitForSeconds(time);

        isOpen = !isOpen;

        if (isOpen)
        {
            anim.SetBool("isOpen", true);
        }
        else
        {
            anim.SetBool("isOpen", false);
        }
    }
}
