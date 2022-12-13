using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRPortalTeleportRay : MonoBehaviour
{
    // Stores a pair of two portals
    private Dictionary<GameObject, GameObject> portalPairs = new Dictionary<GameObject, GameObject>();

    private XRRayInteractor rayInteractor;

    private LineRenderer lineRenderer;

    private void Awake()
    {
        rayInteractor = GetComponent<XRRayInteractor>();

        lineRenderer = rayInteractor.GetComponent<LineRenderer>();
    }

    private void Update()
    {
        GameObject portal = GetPortalIntersection();
        if(portal != null)
        {
            RedirectRay(portal);
        }
    }

    private GameObject GetPortalIntersection()
    {
        Vector3 rayOrigin = rayInteractor.rayOriginTransform.position;
        Vector3 rayDirection = rayInteractor.rayOriginTransform.TransformDirection(rayOrigin); // ?

        RaycastHit hit;
        if(Physics.Raycast(rayOrigin, rayDirection, out hit))
        {
            if(hit.collider.tag == "Portal")
            {
                return hit.collider.gameObject;
            }
        }

        return null;

    }

    private void RedirectRay(GameObject portal)
    {
        GameObject linkedPortal = GetLinkedPortal(portal);

        Vector3 rayOrigin = rayInteractor.rayOriginTransform.position;
        Vector3 rayDirection = rayInteractor.rayOriginTransform.TransformDirection(rayOrigin);

        Vector3 worldRayDirection = portal.transform.TransformDirection(rayDirection);

        Vector3 linkedPortalRayDirection = linkedPortal.transform.InverseTransformDirection(worldRayDirection);

        rayInteractor.rayOriginTransform = linkedPortal.transform;
        rayInteractor.rayOriginTransform.TransformDirection(linkedPortalRayDirection); // ?

        lineRenderer.SetPosition(0, linkedPortal.transform.position);
        lineRenderer.SetPosition(1, linkedPortal.transform.position + linkedPortalRayDirection * rayInteractor.maxRaycastDistance);
    }

    private GameObject GetLinkedPortal(GameObject portal)
    {
        if (portalPairs.ContainsKey(portal))
        {
            return portalPairs[portal];
        }
        else
        {
            return null;
        }
    }

    public void LinkPortals(GameObject portal1, GameObject portal2)
    {
        portalPairs.Add(portal1, portal2);
        portalPairs.Add(portal2, portal1);
    }
}
