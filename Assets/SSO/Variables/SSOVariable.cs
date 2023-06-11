using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace SSO
{
    public abstract class SSOVariable<T> : ScriptableObject,  IScriptableEditor
    {
        public UnityEvent<T> OnValueChanged;

        [SerializeField] protected T value;
        public virtual T Value
        {
            get => value;
            set
            {
                this.value = value;
                OnValueChanged?.Invoke(value);
            }
        }

        protected void CallOnValueChanged(T value)
        {
            OnValueChanged?.Invoke(value);
        }
        
        public virtual void OnInspectorGUI()
        {
        #if UNITY_EDITOR
            
            SerializedObject serializedObject = new SerializedObject(this);
            SerializedProperty property = serializedObject.FindProperty("value");
            
            GUILayout.BeginVertical("VALUE", "window");

            EditorGUILayout.HelpBox("The base editor can only serialize the field value," +
                                    " you can't call OnValueChanged from the inspector", MessageType.Info);
            GUILayout.Space(5);
            serializedObject.Update();
            EditorGUILayout.PropertyField(property, true);
            serializedObject.ApplyModifiedProperties();
            
            GUILayout.EndVertical();

        #endif
        }
    }
}