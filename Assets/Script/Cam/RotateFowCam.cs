using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFowCam : MonoBehaviour
{
    public Transform target; // the object the camera will follow
    public float distance = 10f; // the distance between the camera and target object
    public float height = 5f; // the height of the camera above the target object
    public float rotationSpeed = 1f; // the speed at which the camera will rotate around the target object
    private float currentRotation = 0f; // the current rotation of the camera around the target object
    private void Update()
    {
        // calculate the position of the camera based on the target object's position, distance, and height
        Vector3 targetPosition = target.position + new Vector3(0f, height, -distance);

        // rotate the camera around the target object
        currentRotation += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(0f, currentRotation, 0f);
        Vector3 rotatedPosition = rotation * targetPosition;

        // set the camera's position and rotation
        transform.position = rotatedPosition;
        transform.LookAt(target.position);
    }
}
