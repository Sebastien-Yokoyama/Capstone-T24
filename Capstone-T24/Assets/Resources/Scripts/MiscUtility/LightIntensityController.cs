using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensityController : MonoBehaviour
{
    // The light source whose intensity will be increased
    public Light lightSource;

    // The time it takes for the light intensity to reach the target value
    public float transitionDuration = 1.0f;

    // The target value for the light intensity
    public float targetIntensity = 1.0f;

    // The current value of the light intensity
    private float currentIntensity;

    // The time when the transition started
    private float transitionStartTime;

    private bool startShine = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (!startShine)
        {
            return;
        }

        // Calculate the progress of the transition as a value between 0 and 1
        float transitionProgress = (Time.time - transitionStartTime) / transitionDuration;

        // Clamp the transition progress to the range [0, 1]
        transitionProgress = Mathf.Clamp01(transitionProgress);

        // Calculate the current intensity based on the transition progress
        currentIntensity = Mathf.Lerp(currentIntensity, targetIntensity, transitionProgress);

        // Apply the current intensity to the light source
        lightSource.intensity = currentIntensity;
    }

    public void Initalize()
    {
        // Initialize the current intensity with the light source's starting intensity
        currentIntensity = lightSource.intensity;

        // Record the time when the transition starts
        transitionStartTime = Time.time;

        startShine = true;
    }

    public void InitAtTime(float time)
    {
        StartCoroutine(InitAtCertainTime(time));
    }

    IEnumerator InitAtCertainTime(float time)
    {
        yield return new WaitForSeconds(time);

        Initalize();
    }
}

