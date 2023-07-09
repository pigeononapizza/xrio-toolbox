using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable, Toggle("Enabled")]
public class Description
{
    public bool Enabled;
    [TextArea(3, 10)]
    public string Text;
}

public class DescriptionForObjects : MonoBehaviour
{
    [SerializeField] Description description = new Description();
}

/// <summary>
/// Use this in your script to make a description field that can be toggled on and off.
/// public Description description = new Description();
/// </summary>