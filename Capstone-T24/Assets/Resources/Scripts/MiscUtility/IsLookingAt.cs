using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsLookingAt : MonoBehaviour
{
    //set mask to the mask of the object you
    //want to look at in the editor.
    public LayerMask mask;

    public bool isLooking;

    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, Mathf.Infinity, mask))
        {
            var obj = hit.collider.gameObject;

            isLooking = true;
        }
        else
        {
            isLooking = false;
        }
    }
}
