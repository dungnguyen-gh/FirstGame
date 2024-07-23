using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class HandUp : MonoBehaviour
{
    [SerializeField] private TwoBoneIKConstraint ikConstraint;
    private bool toggle = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            // Toggle the weight value for the two bones in the IK constraint
            toggle = !toggle;
            float weightValue = 1f;
            ikConstraint.data.targetPositionWeight = weightValue;
            
        }
    }
}
