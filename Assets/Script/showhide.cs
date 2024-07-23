using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showhide : MonoBehaviour
{
    public GameObject[] options;
    private int currentOptionIndex;

    void Start()
    {

        currentOptionIndex = 0;

        // Turn all cameras off, except the first default one
        for (int i = 1; i < options.Length; i++)
        {
            options[i].gameObject.SetActive(false);
        }

        // If any cameras were added to the controller, enable the first one
        if (options.Length > 0)
        {
            options[0].gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Switch to the next camera
            int nextOptionIndex = (currentOptionIndex + 1) % options.Length;

            // Disable the current camera, and enable the next one
            options[currentOptionIndex].gameObject.SetActive(false);
            options[nextOptionIndex].gameObject.SetActive(true);

            // Update the current camera index
            currentOptionIndex = nextOptionIndex;
        }
    }
}
