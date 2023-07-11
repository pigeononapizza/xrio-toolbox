using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class DebugEnableDisable : MonoBehaviour
{
    [SerializeField] private GameObject debugTarget;

    void Awake()
    {
        debugTarget = debugTarget != null ? debugTarget : this.gameObject;
    }

    [Button]
    public void DebugEnable()
    {
        debugTarget.SetActive(true);
    }

    [Button]
    public void DebugDisable()
    {
        debugTarget.SetActive(false);
    }
}
