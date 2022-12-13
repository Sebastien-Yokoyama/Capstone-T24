using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class HandAnimAlt : MonoBehaviour
{
    //Stores handPrefab to be Instantiated
    //public GameObject handPrefab;
    
    //Allows for hiding of hand prefab if set to true
    public bool hideHandOnSelect = false;

    //Stores what kind of characteristics we're looking for with our Input Device when we search for it later
    //public InputDeviceCharacteristics inputDeviceCharacteristics;

    public ActionBasedController controller;
    public InputDevice publicController;
    public Animator publicAnimator;
    public SkinnedMeshRenderer publicSMR;

    //Stores the InputDevice that we're Targeting once we find it in InitializeHand()
    private InputDevice _targetDevice;
    private Animator _handAnimator;
    private SkinnedMeshRenderer _handMesh;

    public float triggerValue;
    public float gripValue;

    public void HideHandOnSelect()
    {
        if (hideHandOnSelect)
        {
            _handMesh.enabled = !_handMesh.enabled;
        }
    }
    private void Start()
    {
        //InitializeHand();
        ConnectHand();
    }

    /*
    private void InitializeHand()
    {
        List<InputDevice> devices = new List<InputDevice>();
        //Call InputDevices to see if it can find any devices with the characteristics we're looking for
        InputDevices.GetDevicesWithCharacteristics(inputDeviceCharacteristics, devices);

        //Our hands might not be active and so they will not be generated from the search.
        //We check if any devices are found here to avoid errors.
        if (devices.Count > 0)
        {
            
            _targetDevice = devices[0];

            GameObject spawnedHand = Instantiate(handPrefab, transform);
            _handAnimator = spawnedHand.GetComponent<Animator>();
            _handMesh = spawnedHand.GetComponentInChildren<SkinnedMeshRenderer>();
        }
    }
    */

    private void ConnectHand()
    {
        _targetDevice = publicController;
        _handAnimator = publicAnimator;
        _handMesh = publicSMR;
    }


    // Update is called once per frame
    private void Update()
    {
        /*
        //Since our target device might not register at the start of the scene, we continously check until one is found.
        if(!_targetDevice.isValid)
        {
            //InitializeHand();
            ConnectHand();
            Debug.Log("ERROR: TARGET DEVICE NOT VALID!");
        }
        else
        {
            UpdateHand();
        }
        */
        UpdateHand();
    }

    private void UpdateHand()
    {
        triggerValue = controller.activateAction.action.ReadValue<float>();
        gripValue = controller.selectAction.action.ReadValue<float>();

        _handAnimator.SetFloat("Trigger", triggerValue);
        _handAnimator.SetFloat("Grip", gripValue);

        /*
        //This will get the value for our trigger from the target device and output a flaot into triggerValue
        if (_targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            _handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            _handAnimator.SetFloat("Trigger", 0);
        }
        //This will get the value for our grip from the target device and output a flaot into gripValue
        if (_targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            _handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            _handAnimator.SetFloat("Grip", 0);
        }
        */
    }


}
