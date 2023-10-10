using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Events;


public class SimpleUnityEvents : DebugBehaviour
{
    [SerializeField] private Description description;
    public enum EventOrders { Awake, OnEnable, OnDisable, Start, Update, OnValidate };
    [SerializeField] private EventOrders eventOrder;
    [SerializeField, ShowIf("@eventOrder == EventOrders.OnValidate")] private UnityEvent OnValidateEvent;
    [SerializeField, ShowIf("@eventOrder == EventOrders.Awake")] private UnityEvent OnAwakeEvent;
    [SerializeField, ShowIf("@eventOrder == EventOrders.OnEnable")] private UnityEvent OnEnableEvent;
    [SerializeField, ShowIf("@eventOrder == EventOrders.OnDisable")] private UnityEvent OnDisableEvent;
    [SerializeField, ShowIf("@eventOrder == EventOrders.Start")] private UnityEvent OnStartEvent;
    [SerializeField, ShowIf("@eventOrder == EventOrders.Update")] private UnityEvent OnUpdateEvent;

    #region Unity Functions

    private void OnValidate()
    {
        if (eventOrder == EventOrders.OnValidate)
        {
            DebugInspectorEventProperties(OnValidateEvent);
            OnValidateEvent.Invoke();
        }
    }
    private void Awake()
    {
        if (eventOrder == EventOrders.Awake)
        {
            DebugInspectorEventProperties(OnAwakeEvent);
            OnAwakeEvent.Invoke();
        }
    }
    private void OnEnable()
    {
        if (eventOrder == EventOrders.OnEnable)
        {
            DebugInspectorEventProperties(OnEnableEvent);
            OnEnableEvent.Invoke();
        }
    }
    private void OnDisable()
    {
        if (eventOrder == EventOrders.OnDisable)
        {
            DebugInspectorEventProperties(OnDisableEvent);
            OnDisableEvent.Invoke();
        }
    }
    private void Start()
    {
        if (eventOrder == EventOrders.Start)
        {
            DebugInspectorEventProperties(OnStartEvent);
            OnStartEvent.Invoke();
        }
    }
    private void Update()
    {
        if (eventOrder == EventOrders.Update)
        {
            DebugInspectorEventProperties(OnUpdateEvent);
            OnUpdateEvent.Invoke();
        }
    }
    #endregion


}
