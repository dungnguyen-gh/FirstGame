using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private Light sunLight;
    [SerializeField] private Slider timeSlider;
    [SerializeField] private float dayLength = 120f;
    [SerializeField] private Gradient lightColorGradient;
    [SerializeField] private AnimationCurve lightIntensityCurve;

    private float currentTime = 0f;

    private void Start()
    {
        // Set initial slider value to noon
        timeSlider.value = 0f;
        // Disable auto-lighting baked in Unity lighting settings
        DynamicGI.UpdateEnvironment();
    }

    private void Update()
    {
        // Calculate the current time of day based on slider value
        float timeOfDay = timeSlider.value * dayLength;
        // Update the current time and wrap around if it goes beyond a full day
        currentTime = (currentTime + Time.deltaTime) % dayLength;
        // Calculate the percentage of time passed during the day
        float timePercent = currentTime / dayLength;
        // Calculate the sun's rotation based on the current time of day
        float rotationDegrees = -(timeOfDay / dayLength) * 360f;
        sunLight.transform.rotation = Quaternion.Euler(rotationDegrees, 0f, 0f);
        // Set the sun's color and intensity based on the current time of day
        sunLight.color = lightColorGradient.Evaluate(timePercent);
        sunLight.intensity = lightIntensityCurve.Evaluate(timePercent);
        // Update the lighting for the scene
        DynamicGI.UpdateEnvironment();
    }
}
