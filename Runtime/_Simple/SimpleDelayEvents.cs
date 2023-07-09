using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Events;


[System.Serializable]
public class DelayEvents
{
    public Description description = new Description();
    public float delay = 1f;
    public UnityEvent OnDelayCompleteEvent;
}
public class SimpleDelayEvents : MonoBehaviour
{
    [SerializeField] Description description = new Description();
    [SerializeField] DelayEvents[] DelayEvents;

    [Button]
    public void Delay()
    {
        foreach (var delayEvent in DelayEvents)
        {
            StartCoroutine(DelayRoutine(delayEvent.delay, delayEvent.OnDelayCompleteEvent));
        }
    }

    IEnumerator DelayRoutine(float delay, UnityEvent OnDelayCompleteEvent)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Invoking Delay Events");
        OnDelayCompleteEvent.Invoke();
    }
}

