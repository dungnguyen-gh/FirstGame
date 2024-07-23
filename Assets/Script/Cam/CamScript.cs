using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    // Orbit variables
    public Transform target;
    public float distance = 10.0f;
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;
    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;
    public float distanceMin = .5f;
    public float distanceMax = 15f;
    private float x = 0.0f;
    private float y = 0.0f;

    // Pan variables
    public float panSpeed = 20f;
    private Vector3 lastPanPosition;

    // Zoom variables
    public float zoomSpeed = 5.0f;

    // Move variables
    public float moveSpeed = 10f;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
    }

    void LateUpdate()
    {
        // Orbit the camera
        if (Input.GetMouseButton(0))
        {
            x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            y = ClampAngle(y, yMinLimit, yMaxLimit);

            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;

            transform.rotation = rotation;
            transform.position = position;
        }

        // Pan the camera
        if (Input.GetMouseButton(2))
        {
            Vector3 delta = Input.mousePosition - lastPanPosition;
            Vector3 pan = delta * panSpeed * Time.deltaTime;
            Vector3 pos = transform.position;
            pos.x -= pan.x;
            pos.z -= pan.y;
            transform.position = pos;
        }
        lastPanPosition = Input.mousePosition;

        // Zoom the camera
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance = Mathf.Clamp(distance - scroll * zoomSpeed, distanceMin, distanceMax);

        // Move the camera
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(new Vector3(horizontal, 0, vertical));
    }

    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360f)
            angle += 360f;
        if (angle > 360f)
            angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }
}
