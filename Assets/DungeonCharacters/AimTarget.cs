using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AimTarget : MonoBehaviour
{
    public float force;
    public GameObject TargetEnd;
    private Vector3 aim;

    // Update is called once per frame
    void Update()
    {
        Camera cam = Camera.main;
        Vector3 mousePos = Input.mousePosition;
        aim = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));
    }
}
