using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFloating : MonoBehaviour
{
    public float Amplitude = 1f;
    public float Speed = 1f;
    Vector3 startPos;
    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        Vector3 newPos = new Vector3(startPos.x, startPos.y + Mathf.Sin(Time.time * Speed) * Amplitude, startPos.z);
        transform.localPosition = newPos;
        //print(Mathf.Sin(Time.time));
    }
}
