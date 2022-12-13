using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This button works via colliders, NOT XRInteraction.
/// 
/// IMPORTANT: If you want to rotate this button (in the editor). DO NOT rotate the primary parent (Empty) GameObject. Rotate "Base" instead.
/// </summary>
public class CollisionButton : MonoBehaviour
{
    public Rigidbody buttonTopRigid;
    public Transform buttonTop;
    public Transform buttonLowerLimit;
    public Transform buttonUpperLimit;
    public float threshHold;
    public float force = 10;
    private float upperLowerDiff;
    public bool isPressed;
    private bool prevPressedState;
    public AudioSource pressedSound;
    public AudioSource releasedSound;
    public Collider[] CollidersToIgnore;
    public UnityEvent onPressed;
    public UnityEvent onReleased;

    public GameObject buttonObject;

    // Start is called before the first frame update
    void Start()
    {
        Collider localCollider = GetComponent<Collider>();
        if (localCollider != null)
        {
            Physics.IgnoreCollision(localCollider, buttonTop.GetComponentInChildren<Collider>());

            foreach (Collider singleCollider in CollidersToIgnore)
            {
                Physics.IgnoreCollision(localCollider, singleCollider);
            }
        }
        
        if (transform.eulerAngles != Vector3.zero){
            Vector3 savedAngle = transform.eulerAngles;
            transform.eulerAngles = Vector3.zero;
            upperLowerDiff = buttonUpperLimit.position.y - buttonLowerLimit.position.y;
            transform.eulerAngles = savedAngle;
        }
        else
            upperLowerDiff = buttonUpperLimit.position.y - buttonLowerLimit.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        buttonTop.transform.localPosition = new Vector3(0, buttonTop.transform.localPosition.y, 0);
        buttonTop.transform.localEulerAngles = new Vector3(0, 0, 0);
        if (buttonTop.localPosition.y >= 0)
            buttonTop.transform.position = new Vector3(buttonUpperLimit.position.x, buttonUpperLimit.position.y, buttonUpperLimit.position.z);
        else
            buttonTopRigid.AddForce(buttonTop.transform.up * force * Time.deltaTime);

        if (buttonTop.localPosition.y <= buttonLowerLimit.localPosition.y)
            buttonTop.transform.position = new Vector3(buttonLowerLimit.position.x, buttonLowerLimit.position.y, buttonLowerLimit.position.z);

        if (disabled)
        {
            return;
        }

        if (Vector3.Distance(buttonTop.position, buttonLowerLimit.position) < upperLowerDiff * threshHold)
            isPressed = true;
        else
            isPressed = false;

        if(isPressed && prevPressedState != isPressed)
            Pressed();
        if(!isPressed && prevPressedState != isPressed)
            Released();
    }

    // void FixedUpdate(){
    //     Vector3 localVelocity = transform.InverseTransformDirection(buttonTop.GetComponent<Rigidbody>().velocity);
    //     Rigidbody rb = buttonTop.GetComponent<Rigidbody>();
    //     localVelocity.x = 0;
    //     localVelocity.z = 0;
    //     rb.velocity = transform.TransformDirection(localVelocity);
    // }

    void Pressed(){
        prevPressedState = isPressed;
        //pressedSound.pitch = 1;
        //pressedSound.Play();
        onPressed.Invoke();
    }

    void Released(){
        prevPressedState = isPressed;
        //releasedSound.pitch = Random.Range(1.1f, 1.2f);
        //releasedSound.Play();
        onReleased.Invoke();
    }

    // Events

    private bool doOnce = false;
    private bool doOnce2 = false;

    public bool disabled = false;
    public Material enabledMat = null;
    public Material disabledMat = null;

    public void DisablePress(float timeToDisable)
    {
        if (!doOnce)
        {
            StartCoroutine(DisableButton(timeToDisable));
        }
        doOnce = true;
    }

    IEnumerator DisableButton(float timeToDisable)
    {
        yield return new WaitForSeconds(timeToDisable);

        buttonObject.GetComponent<MeshRenderer>().material = disabledMat;
        disabled = true;
    }

    public void EnablePress(float timeToEnable)
    {
        if (!doOnce2)
        {
            StartCoroutine(EnableButton(timeToEnable));
        }
        doOnce2 = true;
    }

    IEnumerator EnableButton(float timeToEnable)
    {
        yield return new WaitForSeconds(timeToEnable);

        buttonObject.GetComponent<MeshRenderer>().material = enabledMat;
        disabled = false;
    }
}
