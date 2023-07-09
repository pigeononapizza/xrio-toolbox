using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//clicking '?' in upper right corner of inspector componenet executes HelpURL link
[HelpURL("https://unity3d.college/2017/05/22/unity-attributes/")] 
public class InspectorAttributes : MonoBehaviour
{
    [Header("Headers act a titles to groups")]

    [Header("Numeric Attributes")]
    [Tooltip("A float using the Range attribute")]
    [SerializeField]//this makes private variables visible in inspector
    [Range(-5f, 5f)]
    private float _rangedFloat;
    [SerializeField]
    [Range(-5, 5)]
    private int _rangedInt;

    [Space]
    [Header("Text Attributes")]
    [Tooltip("A string using the TextArea attribute")]
    [TextArea(1, 5)] //(minLines, maxLines)
    [SerializeField]
    private string _textArea;
    [Tooltip("A string using the Multiline attribute")]
    [Multiline]
    [SerializeField]
    private string _multiline;

    [Space]
    [Header("Color Attributes")]

    [SerializeField]
    private Color _colorNormal;

    [ColorUsage(false)]
    [SerializeField]
    private Color _colorNoAlpha;

    [ColorUsage(true, true)]
    [SerializeField]
    private Color _colorHdr;

    [ContextMenu("Choose Random Values")]
    private void ChooseRandomValues()
    {
        _rangedFloat = Random.Range(-5f, 5f);
        _rangedInt = Random.Range(-5, 5);
    }

    [Header("Context Menu Items")]
    [ContextMenuItem("RandomValue", "RandomizeValueFromRightClick")]
    [SerializeField]
    private float _randomValue;

    private void RandomizeValueFromRightClick()
    {
        _randomValue = Random.Range(-5f, 5f);
    }

    [Header("Enum Attributes")]
    public ModelImporterIndexFormat FormatType;
    public enum ModelImporterIndexFormat
    {
        Auto = 0,
        [InspectorName("16 bits")]
        UInt16 = 1,
        [InspectorName("32 bits")]
        UInt32 = 2,
    }

}
