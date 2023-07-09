using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[CreateAssetMenu(fileName = "ScriptableExample", menuName = "Examples/ScriptableExample")]
public class ref_ScriptableExample : ScriptableObject
{
    public List<KeyValuePair_SelfieCam> SelfieCamConfiguration;
    public Dictionary<int, List<SelfieCamClass>> SelfieCamConfigDictionary = new Dictionary<int, List<SelfieCamClass>>();
    private void OnEnable()
    {
        foreach (var kvp in SelfieCamConfiguration)
        {
            SelfieCamConfigDictionary[kvp.key_POI] = kvp.val_PoseID;
        }
    }
}

/// <summary>
/// Structs defined for Scriptable
/// </summary>
[Serializable]
public struct SelfieCamTransform
{
    public Vector3 Postion;
    public Vector3 Rotation;
    public Vector3 Scale;
}
[Serializable]
public struct SelfieCamClass
{
    public int PoseID;
    public SelfieCamTransform SelfieCamTransform;
}
[Serializable]
public struct KeyValuePair_SelfieCam
{
    public int key_POI;
    public string Description;
    public List<SelfieCamClass> val_PoseID;
}
