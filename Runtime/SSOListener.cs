using UnityEngine;
using UnityEngine.Events;

namespace SSO.Events
{
    public class SSOListener : MonoBehaviour
    {
        public SSOEvent Event;
        public UnityEvent EventTriggered;

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