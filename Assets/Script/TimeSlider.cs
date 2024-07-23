using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSlider : MonoBehaviour
{
    [SerializeField] private Slider dayNightSlider;
    [SerializeField] private Light sunLight;

    void Start()
    {
        // Set the slider value to the current rotation of the sun light
        dayNightSlider.value = sunLight.transform.rotation.eulerAngles.x / 360f;

        // Subscribe to the OnValueChanged event of the slider
        dayNightSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    void OnSliderValueChanged(float value)
    {
        // Set the rotation of the sun light based on the slider value
        sunLight.transform.rotation = Quaternion.Euler(value * 360f, -30f, 0f);
    }
}
