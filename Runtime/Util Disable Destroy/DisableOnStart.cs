using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnStart : MonoBehaviour
{
    [Tooltip("If this is null, this object will be disabled on awake. Otherwise, the objectToDisable will be disabled on awake.")]
    public GameObject objectToDisable;
    void Awake()
    {
        if (objectToDisable == null)
        {
            this.gameObject.SetActive(false);
        }
        else{
            objectToDisable.SetActive(false);
        }

    }

}
