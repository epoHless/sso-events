using System;
using System.Collections.Generic;
using UnityEngine;

namespace SSO
{
    [CreateAssetMenu(menuName = "SSO/Events/New Event")]
    public class SSOEvent : ScriptableObject
    {
        private List<SSOListener> listeners = new List<SSOListener>();
        public List<SSOListener> Listeners => listeners;
        
        public int ListenersCount => listeners.Count;

        private void OnEnable()
        {
            listeners = new List<SSOListener>();
        }

        public void TriggerEvent()
        {
            for (int i = listeners.Count -1; i >= 0; i--)
            {
                listeners[i].OnEventTriggered();
            }
        }
    
        public void Add(SSOListener listener)
        {
            if(!listeners.Contains(listener)) listeners.Add(listener);
        }
        public void Remove(SSOListener listener)
        {
            if(listeners.Contains(listener)) listeners.Remove(listener);
        }
    }

}

