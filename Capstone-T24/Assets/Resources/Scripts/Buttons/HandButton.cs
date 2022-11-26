using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class HandButton : XRBaseInteractable
{
    public UnityEvent OnPress = null;

    private float yMin = 0.0f;
    private float yMax = 0.0f;
    public float magicThreshold = 0.01f;
    private bool previousPress = false;

    private float previousHandHeight = 0.0f;
    private XRBaseInteractor hoverInteractor = null;

    public bool disabled = false;
    public Material enabledMat = null;
    public Material disabledMat = null;

    private bool doOnce = false;
    private bool doOnce2 = false;

    protected override void Awake()
    {
        base.Awake();
        onHoverEntered.AddListener(StartPress);
        onHoverExited.AddListener(EndPress);
    }

    private void OnDestroy()
    {
        onHoverEntered.RemoveListener(StartPress);
        onHoverExited.RemoveListener(EndPress);
    }

    private void StartPress(XRBaseInteractor interactor)
    {
        hoverInteractor = interactor;
        previousHandHeight = GetLocalYPosition(hoverInteractor.transform.position);
    }

    private void EndPress(XRBaseInteractor interactor)
    {
        hoverInteractor = null;
        previousHandHeight = 0.0f;

        previousPress = false;
        SetYPosition(yMax);
    }

    private void Start()
    {
        SetMinMax();

        if(disabledMat != null && disabled)
        {
            this.GetComponent<MeshRenderer>().material = disabledMat;
        }
    }

    private void SetMinMax()
    {
        Collider collider = GetComponent<Collider>();
        yMin = transform.localPosition.y - (collider.bounds.size.y * 0.5f); // Height of the button halved
        yMax = transform.localPosition.y;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if (disabled)
        {
            return;
        }

        if (hoverInteractor)
        {
            float newHandHeight = GetLocalYPosition(hoverInteractor.transform.position);
            float handDifference = previousHandHeight - newHandHeight;
            previousHandHeight = newHandHeight;

            float newPosition = transform.localPosition.y - handDifference;
            SetYPosition(newPosition);

            CheckPress();
        }
    }

    private float GetLocalYPosition(Vector3 position)
    {
        Vector3 localPosition = transform.root.InverseTransformPoint(position);

        return localPosition.y;
    }

    private void SetYPosition(float position)
    {
        Vector3 newPosition = transform.localPosition;
        newPosition.y = Mathf.Clamp(position, yMin, yMax);
        transform.localPosition = newPosition;
    }

    private void CheckPress()
    {
        bool inPosition = InPosition();

        if (inPosition && inPosition != previousPress)
        {
            OnPress.Invoke();
        }

        previousPress = inPosition;
    }

    private bool InPosition()
    {
        float inRange = Mathf.Clamp(transform.localPosition.y, yMin, yMin + magicThreshold);

        return transform.localPosition.y == inRange;
    }

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

        this.GetComponent<MeshRenderer>().material = disabledMat;
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

        this.GetComponent<MeshRenderer>().material = enabledMat;
        disabled = false;
    }
}
