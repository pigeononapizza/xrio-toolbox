using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Events;

/// <summary>
/// This script is used to get the GUI events from the Unity GUI system
/// Useful when running VR apps in the editor
/// </summary>

[System.Serializable]
public class GUIEvents
{
    public string EventName;
    public Description description = new Description();
    public UnityEvent OnClickEvent;
}

public class GetGUIEvents : MonoBehaviour
{
    [Header("Xpos|Ypos|Width|Height (0,0,0,0)")]
    [SerializeField, FoldoutGroup("GUI Customization")]
    private Vector4 GUIRect = new Vector4(50, 50, 100, 20);

    public enum HorJustification { Left, Center, Right };
    public enum VertJustification { Top, Center, Bottom };

    [SerializeField, FoldoutGroup("GUI Customization")]
    HorJustification h_Justify = HorJustification.Left;

    [SerializeField, FoldoutGroup("GUI Customization")]
    VertJustification v_Justify = VertJustification.Top;
    [SerializeField, FoldoutGroup("GUI Customization")]
    float VerticalSpacing = 50;

    [SerializeField] GUIEvents[] CustomGUIEvents;
    [SerializeField, FoldoutGroup("Debug Customization")]
    private Color debugColor = Color.green;
    void OnGUI()
    {
        float xAlignment = GUIRect.x;
        float yAlignment = GUIRect.y;
        switch (h_Justify)
        {
            case HorJustification.Left:
                xAlignment = GUIRect.x;
                break;
            case HorJustification.Center:
                xAlignment = Screen.width / 2 - GUIRect.z / 2;
                break;
            case HorJustification.Right:
                xAlignment = Screen.width - GUIRect.x - GUIRect.z;
                break;
        }
        switch (v_Justify)
        {
            case VertJustification.Top:
                yAlignment = GUIRect.y;
                break;
            case VertJustification.Center:
                yAlignment = Screen.height / 2 - GUIRect.w / 2;
                break;
            case VertJustification.Bottom:
                yAlignment = Screen.height - GUIRect.y - GUIRect.w;
                break;
        }
        for (int i = 0; i < CustomGUIEvents.Length; i++)
        {
            string thisEvent = CustomGUIEvents[i].EventName;
            if (GUI.Button(new Rect(xAlignment, yAlignmentAdjusted(yAlignment, i), GUIRect.z, GUIRect.w), thisEvent))
            {
                string debug = $"{dColor}{thisEvent}{dEndCol} was pressed on {dColor}{gameObject.name}{dEndCol}";
                Debug.Log(debug, gameObject);
                CustomGUIEvents[i].OnClickEvent?.Invoke();
            }
        }
    }


    float yAlignmentAdjusted(float curYAlignment, int index)
    {
        float yAlignment = curYAlignment;
        switch (v_Justify)
        {
            case VertJustification.Top:
                yAlignment = curYAlignment + VerticalSpacing * index;
                break;
            case VertJustification.Center:
                yAlignment = curYAlignment + VerticalSpacing * index;
                break;
            case VertJustification.Bottom:
                yAlignment = curYAlignment - VerticalSpacing * index;
                break;
        }
        return yAlignment;
    }

    string dColor => DebugColorConverter.Start(debugColor);
    string dEndCol => DebugColorConverter.End();
}


