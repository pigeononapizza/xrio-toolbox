using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ToolBox
{
    /// <summary>
    /// Zero out the transform's world position and rotation
    /// </summary>
    /// <param name="transform"></param>
    public static void ZeroWorldTransformValues(Transform transform)
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
    }
    /// <summary>
    /// Zero out the transform's local position and rotation
    /// </summary>
    /// <param name="transform"></param>
    public static void ZeroLocalTransformValues(Transform transform)
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
}
