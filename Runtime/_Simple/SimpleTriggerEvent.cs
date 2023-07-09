using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace XRIO
{
    public class TriggerEvent : MonoBehaviour
    {
        [SerializeField]
        string _compareTag = "Player";

        public UnityEvent OnTriggerEnterEvent;
        public UnityEvent OnTriggerExitEvent;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(_compareTag))
            {
                OnTriggerEnterEvent.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag(_compareTag))
            {
                OnTriggerExitEvent.Invoke();
            }
        }

    }
}
