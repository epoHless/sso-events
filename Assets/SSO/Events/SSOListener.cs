﻿using UnityEngine;
using UnityEngine.Events;

namespace SSO
{
    public class SSOListener : MonoBehaviour
    {
        public SSOEvent Event;
        [SerializeField] protected UnityEvent EventTriggered;

        void OnEnable()
        {
            Event.Add(this);
        }
        
        void OnDisable()
        {
            Event.Remove(this);
        }

        public void OnEventTriggered()
        {
            EventTriggered.Invoke();
        }
    }
}