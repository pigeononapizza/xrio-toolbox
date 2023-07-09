using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Generic Events 
[System.Serializable]
public class StringEvent : UnityEvent<string> { }
public class Refs_UnityEvents : MonoBehaviour
{
    public UnityEvent simpleUnityEvent;  
    public StringEvent stringEvent;
    // Start is called before the first frame update
    void Start()
    {
        InvokeUnityEvent();
    }

    // Update is called once per frame
    public void InvokeUnityEvent()
    {
        if (simpleUnityEvent != null)
        {
            simpleUnityEvent.Invoke();
        }
        if (stringEvent != null)
        {
            stringEvent.Invoke("Hello World");
        }
        
    }
}
