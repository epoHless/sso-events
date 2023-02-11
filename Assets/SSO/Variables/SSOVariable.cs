using System;
using UnityEngine;

namespace SSO
{

    public abstract class SSOVariable<T> : ScriptableObject
    {
        public abstract T Value { get; set; }

        protected void TriggerValueChanged() => OnValueChanged?.Invoke();

        public delegate void ValueChanged();

        public event ValueChanged OnValueChanged;

        public void OnValidate()
        {
            TriggerValueChanged();
        }
    }

}