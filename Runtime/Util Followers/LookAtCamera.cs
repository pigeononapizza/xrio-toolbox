using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    /// <summary>
    /// This script works well for VR
    /// </summary>

    /// <summary>
    /// Offset from Object we are providing tip to
    /// </summary>
    public Vector3 TipOffset = new Vector3(.25f, 0.15f, 0);
    public Vector3 RotationOffset = new Vector3(0f, 0f, 0f);

    /// <summary>
    /// If true Y axis will be in World Coordinates. False for local coords.
    /// </summary>
    public bool UseWorldYAxis = true;

    /// <summary>
    /// Hide the tooltip if Camera is farther away than this. In meters.
    /// </summary>
    public float MaxViewDistance = 10f;

    /// <summary>
    /// Hide this if farther than MaxViewDistance
    /// </summary>
    Transform childTransform;

    Transform lookAt;

    void Start()
    {
        lookAt = Camera.main.transform;
        if (transform.childCount > 0)
            childTransform = transform.GetChild(0);
    }

    void Update()
    {
        if (lookAt)
        {
            transform.LookAt(Camera.main.transform);
            transform.rotation *= Quaternion.Euler(RotationOffset);
        }
        else if (Camera.main != null)
        {
            lookAt = Camera.main.transform;
        }
        else if (Camera.main == null)
        {
            return;
        }

        transform.localPosition = TipOffset;

        if (UseWorldYAxis)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 0, transform.localPosition.z);
            transform.position += new Vector3(0, TipOffset.y, 0);
        }

        if (childTransform)
        {
            childTransform.gameObject.SetActive(Vector3.Distance(transform.position, Camera.main.transform.position) <= MaxViewDistance);
        }
    }
}
