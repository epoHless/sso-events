using System.Collections.Generic;
using UnityEngine;

namespace SSO
{
    public abstract class SSOEvent : ScriptableObject
    {
        private List<SSOListener> listeners = new List<SSOListener>();
    
        public void TriggerEvent()
        {
            for (int i = listeners.Count -1; i >= 0; i--)
            {
                listeners[i].OnEventTriggered();
            }
        }
    
        public void AddListener(SSOListener listener)
        {
            listeners.Add(listener);
        }
        public void RemoveListener(SSOListener listener)
        {
            listeners.Remove(listener);
        }
    }

}

