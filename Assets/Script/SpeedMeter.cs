using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedMeter : MonoBehaviour
{
    public Rigidbody carRigidbody;
    public Text speedText;

    // Update is called once per frame
    void Update()
    {
        float speed = carRigidbody.velocity.magnitude * 3.6f; // convert m/s to km/h
        float forwardSpeed = Vector3.Dot(carRigidbody.velocity, transform.forward);
        if (forwardSpeed >= 0f)
        {
            speedText.text = "Speed: " + speed.ToString("0") + " km/h";
        }
        else
        {
            speedText.text = "Speed: 0 km/h";
        }
    }
}
