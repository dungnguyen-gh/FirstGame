using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material[] materials; // the array of materials to apply to the object
    public KeyCode changeKey; // the key to press to change the material
    public int currentMaterialIndex; // the index of the current material in the materials array

    private Renderer objectRenderer; // the renderer component of the object

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        currentMaterialIndex = 0;
        objectRenderer.material = materials[currentMaterialIndex];
    }

    void Update()
    {
        if (Input.GetKeyDown(changeKey))
        {
            currentMaterialIndex = (currentMaterialIndex + 1) % materials.Length;
            objectRenderer.material = materials[currentMaterialIndex];
        }
    }
}
