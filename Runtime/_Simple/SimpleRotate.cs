using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotate : MonoBehaviour
{
    public bool IsEnabled = default;
    public float SpinSpeed = 360f;
    
    public enum AxisTypes {X,Y,Z};
    public AxisTypes AxisOfRotation = default;

    Vector3 currentAxis;

    void Update()
    {
        if (IsEnabled)
        {
            switch (AxisOfRotation)
            {
                case AxisTypes.X:
                    currentAxis = Vector3.right;
                    break;
                case AxisTypes.Y:
                    currentAxis = Vector3.up;
                    break;
                case AxisTypes.Z:
                    currentAxis = Vector3.forward;
                    break;
            }
            GetComponent<Transform>().Rotate(currentAxis * SpinSpeed * Time.deltaTime);
        }
    }

    public void EnableRotation(bool isEnabled)
    {
        IsEnabled = isEnabled;
    }
}
