/*
 * Originally developed by: [UNKNOWN]
 * Modified  by: Cody Jackson
 * Video: [UNKNOWN]
 * File Name: HandsAnimHelper.cs
 * File Description: Helper script for hand animations. [UNUSED]
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandsAnimHelper : MonoBehaviour
{
    ActionBasedController controller;

    public AdvancedHands hand;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<ActionBasedController>();
    }

    // Update is called once per frame
    void Update()
    {
        //hand.SetGrip(controller.selectAction.action.ReadValue<float>());
        //hand.SetTrigger(controller.activateAction.action.ReadValue<float>());
    }
}
