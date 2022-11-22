using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericTrigger : MonoBehaviour
{
    [Tooltip("The ID of the event that this trigger will cause when activated.")]
    public int eventToTrigger;


    private void OnTriggerEnter(Collider other)
    {
                
    }

    private void OnTriggerExit(Collider other)
    {
           
    }

}
