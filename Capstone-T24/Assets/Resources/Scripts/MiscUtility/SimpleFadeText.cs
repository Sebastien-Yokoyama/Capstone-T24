using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFadeText : MonoBehaviour
{
    public Animator anim;
    public bool isVisible;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeIn()
    {
        isVisible = true;
        anim.SetBool("isVisible", true);
    }

    public void FadeInAtTime(float time)
    {
        StartCoroutine(FadeInTime(time));
    }

    IEnumerator FadeInTime(float time)
    {
        yield return new WaitForSeconds(time);

        FadeIn();
    }
}
