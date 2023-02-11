using UnityEngine;
using UnityEngine.Events;

namespace SSO
{

    public class SSOListener : MonoBehaviour
    {
        public SSOEvent _event;
        public UnityEvent onEventTriggered;
        
        void OnEnable()
        {
            _event.AddListener(this);
        }
        
        void OnDisable()
        {
            _event.RemoveListener(this);
        }
        
        public void OnEventTriggered()
        {
            onEventTriggered.Invoke();
        }
    }

}