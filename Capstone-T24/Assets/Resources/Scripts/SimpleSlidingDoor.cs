using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSlidingDoor : MonoBehaviour
{
    /// <summary>
    /// Does this door open automatically when the player enters the trigger area?
    /// </summary>
    public bool isAuto;
    /// <summary>
    /// Does this door open at all?
    /// </summary>
    public bool isStatic;
    public Animator anim;
    public bool canBeOpened;

    public AudioSource audioSource;
    public AudioClip openSound;
    public AudioClip closeSound;

    private bool doOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && isAuto && !isStatic)
        {
            OpenDoor();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && !isAuto && !isStatic)
        {
            canBeOpened = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !isStatic)
        {
            CloseDoor();
            canBeOpened = false;
        }
    }

    private void OpenDoor()
    {
        anim.SetBool("Open", true);
        audioSource.PlayOneShot(openSound);
    }
    private void CloseDoor()
    {
        anim.SetBool("Open", false);
        audioSource.PlayOneShot(closeSound);
    }

    public void OpenDirectly()
    {
        OpenDoor();
    }

    public void OpenDirectlyAfterTime(float time)
    {
        if (doOnce)
        {
            return;
        }
        doOnce = true;
        StartCoroutine(OpenTimed(time));
    }

    IEnumerator OpenTimed(float time)
    {
        yield return new WaitForSeconds(time);

        OpenDirectly();
        doOnce = false;
    }

    public void DisableDoor()
    {
        isStatic = true;
    }

    public void EnableDoor()
    {
        isStatic = false;
    }
}
