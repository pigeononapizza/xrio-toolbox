using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

[HelpURL("https://forum.unity.com/threads/solved-when-input-field-is-active-disable-if-input-getkeyup-keycode-b.715253/")]
public class InputFieldActive_UniversalWatcher : MonoBehaviour
{
    EventSystem system;
    public bool InputFieldSelected = false;


    public UnityEvent<bool> InputFieldSelectedEvent;


    void OnEnable()
    {
        system = EventSystem.current;
    }

    void Update()
    {
        if (system == null)
        {
            system = EventSystem.current;
            if (system == null) return;
        }

        GameObject currentObject = system.currentSelectedGameObject;
        if (currentObject != null)
        {
            InputField inputField = currentObject.GetComponent<InputField>();
            TMP_InputField tmpInput = currentObject.GetComponent<TMP_InputField>();
            if (!InputFieldSelected && inputField != null)
            {
                InputFieldSelected = true;
                InputFieldSelectedEvent.Invoke(InputFieldSelected);
            }
            else if (InputFieldSelected && inputField == null)
            {
                InputFieldSelected = false;
                InputFieldSelectedEvent.Invoke(InputFieldSelected);
            }
            else if (!InputFieldSelected && tmpInput != null)
            {
                InputFieldSelected = true;
                InputFieldSelectedEvent.Invoke(InputFieldSelected);
            }
            else if (InputFieldSelected && tmpInput == null)
            {
                InputFieldSelected = false;
                InputFieldSelectedEvent.Invoke(InputFieldSelected);
            }
        }
    }
}
