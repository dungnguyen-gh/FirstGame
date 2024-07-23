using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



public class LineDraw : MonoBehaviour
{
    private bool drawing = false;
    public Text txt;
    public Button btn;
    public GameObject objectToAffect;
    private RaycastHit hit1;
    private RaycastHit hit2;
    private int count = 0;
    private void Start()
    {
        AddListener();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && count == 1)
        {
            if (!drawing)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit1))
                {
                    Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red, 5000);
                    Debug.Log("CC1:" + hit1.point);
                    drawing = true;
                }

            }
            else if (drawing)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit2))
                {
                    drawing = false;
                    DrawLine();
                    float distance = Vector3.Distance(hit1.point, hit2.point);
                    txt.text = distance.ToString() + "m";
                    Debug.Log("Distance: " + txt.text);
                }

            }
        }
    }

    private void AddListener()
    {
        btn.onClick.AddListener(OnClick);
    }


    void OnClick()
    {
        drawing = false;
        Debug.Log("0");
        count = 1;
    }

    void DrawLine()
    {
        GameObject line = new GameObject("Line");
        line.AddComponent<LineRenderer>();
        LineRenderer lineRenderer = line.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2; 
        lineRenderer.startWidth = 0.5f;
        lineRenderer.endWidth = 0.5f;
        lineRenderer.SetPosition(0, hit1.point);
        lineRenderer.SetPosition(1, hit2.point);
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(line, 1.5f);
        }
    }
}