using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleOscillate : MonoBehaviour
{
    public bool IsEnabled = true;
    public enum AxisTypes { X, Y, Z };
    public AxisTypes OscillationAxis = default;

    public float Amplitude = 1f;
    public float Speed = 1f;
    Vector3 startPos;

    Vector3 temp;
    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {

        float curSinVal = Mathf.Sin(Time.time * Speed) * Amplitude;
        if (IsEnabled)
        {
            switch (OscillationAxis)
            {
                case AxisTypes.X:
                    temp = Vector3.right * curSinVal;
                    break;
                case AxisTypes.Y:
                    temp = Vector3.up * curSinVal;
                    break;
                case AxisTypes.Z:
                    temp = Vector3.forward * curSinVal;
                    break;
            }

            Vector3 newPos = new Vector3(startPos.x + temp.x, startPos.y + temp.y, startPos.z + temp.z);
            transform.localPosition = newPos;
        }

        //print(Mathf.Sin(Time.time));
    }

    public void EnableOscillation(bool isEnabled)
    {
        IsEnabled = isEnabled;
    }
}
