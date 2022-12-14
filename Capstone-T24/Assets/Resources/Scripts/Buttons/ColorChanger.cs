/*
 * Originally developed by: VR with Andrew [possibly wrong]
 * Modified  by: Cody Jackson
 * Video: https://www.youtube.com/watch?v=pmRwhE2hQ9g [possibly wrong]
 * File Name: ColorChanger.cs
 * File Description: Changes the color of an object when the user hovers their hand over it. Uses XR Toolkit.
 */

using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ColorChanger : MonoBehaviour
{
    public Material selectMaterial = null;

    private MeshRenderer meshRenderer = null;
    private XRBaseInteractable interactable = null;
    private Material originalMaterial = null;

    public bool doOnce = false;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalMaterial = meshRenderer.material;

        interactable = GetComponent<XRBaseInteractable>();
        interactable.onHoverEntered.AddListener(SetSelectMaterial);
        interactable.onHoverExited.AddListener(SetOriginalMaterial);
    }

    private void OnDestroy()
    {
        interactable.onHoverEntered.RemoveListener(SetSelectMaterial);
        interactable.onHoverExited.RemoveListener(SetOriginalMaterial);
    }

    private void SetSelectMaterial(XRBaseInteractor interactor)
    {
        meshRenderer.material = selectMaterial;
    }

    private void SetOriginalMaterial(XRBaseInteractor interactor)
    {
        meshRenderer.material = originalMaterial;
    }

    public void RemoveListeners(float time)
    {
        if (!doOnce)
        {
            StartCoroutine(RemoveListenAtTime(time));
        }
        doOnce = true;
    }

    IEnumerator RemoveListenAtTime(float time)
    {
        yield return new WaitForSeconds(time);

        interactable.onHoverEntered.RemoveListener(SetSelectMaterial);
        interactable.onHoverExited.RemoveListener(SetOriginalMaterial);
    }
}
