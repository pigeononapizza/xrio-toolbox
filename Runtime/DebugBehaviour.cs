using UnityEngine;
using Sirenix.OdinInspector;

public class DebugBehaviour : MonoBehaviour
{
    [SerializeField, FoldoutGroup("Debugging")] protected bool debugMode = true;
    public bool DebugMode => debugMode;
    [SerializeField, FoldoutGroup("Debugging")] private Color debugColor = Color.white;

    protected virtual void DebugMessage(string message)
    {
        string debugMessage = $"{dColor}{message}{dEndCol}";
        if (/*DebugHelper.Instance.DebugModeActive &&*/ debugMode)
            Debug.Log(debugMessage, this.gameObject);
        //Are you here because of Console -> LineTrace? 
        //Use Console Pro 3 Window. Then line trace to just before this log!  
        //Window -> Console Pro 3
    }
    protected virtual void DebugWarning(string message)
    {
        string debugMessage = $"{dColor}{message}{dEndCol}";
        Debug.LogWarning(debugMessage);
    }
    protected virtual void DebugError(string message)
    {
        string debugMessage = $"{dColor}{message}{dEndCol}";
        Debug.LogError(debugMessage);
    }

    ///<summary>
    ///Debugs the persistent events of a UnityEvent. These are events assigned in the inspector.
    ///</summary>
    protected virtual void DebugInspectorEventProperties(UnityEngine.Events.UnityEvent targetEvent, bool showAllPersistentEvents = true)
    {
        string debugMessage = $"{dColor}{targetEvent.ToString()} has {targetEvent.GetPersistentEventCount()} persistent events.{dEndCol}";
        Debug.Log(debugMessage, this.gameObject);
        if (showAllPersistentEvents)
        {
            for (int i = 0; i < targetEvent.GetPersistentEventCount(); i++)
            {
                string debugMessageExt = $"{dColor}InspectorEvent {i} is <b>{targetEvent.GetPersistentMethodName(i)}</b> on <b>{targetEvent.GetPersistentTarget(i)}</b>{dEndCol}";
                Debug.Log(debugMessageExt, targetEvent.GetPersistentTarget(i));
            }
        }
    }

    protected string dColor => DebugColor.Start(debugColor);
    protected string dEndCol => DebugColor.End();
}

