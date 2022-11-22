using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSlidingDoor : MonoBehaviour
{
    public bool isAuto;
    public Animator anim;
    public bool canBeOpened;

    public AudioSource audioSource;
    public AudioClip openSound;
    public AudioClip closeSound;

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
        if(other.tag == "Player" && isAuto)
        {
            OpenDoor();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && !isAuto)
        {
            canBeOpened = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
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
}
