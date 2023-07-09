using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpin : MonoBehaviour
{

    // simple rotation around the Y-axis
    public float speed = 5.0f;

    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
