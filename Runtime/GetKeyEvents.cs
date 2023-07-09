using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class KeyEvents
{

    public KeyCode InputKey;
    public string eventName;
    public Description description = new Description();
    public UnityEvent KeyDownEvent;
}
public class GetKeyEvents : MonoBehaviour
{
    public KeyEvents[] CustomKeyEvents;

    void Update()
    {
        for (int i = 0; i < CustomKeyEvents.Length; i++)
        {
            if (Input.GetKeyDown(CustomKeyEvents[i].InputKey))
            {
                string debug = $"<color=green>{CustomKeyEvents[i].InputKey}</color> was pressed on <color=green>{gameObject.name}</color>";
                //check if the event name is empty
                if (CustomKeyEvents[i].eventName != string.Empty)
                {
                    debug += $"\n<color=yellow>{CustomKeyEvents[i].eventName}</color> ";
                }
                Debug.Log(debug, gameObject);
                CustomKeyEvents[i].KeyDownEvent?.Invoke();
            }
        }
    }
}
