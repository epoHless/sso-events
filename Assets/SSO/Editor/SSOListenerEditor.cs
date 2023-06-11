﻿using UnityEditor;
using UnityEngine;

namespace SSO
{
    [CustomEditor(typeof(SSOListener))]
    public class SSOListenerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var script = (SSOListener)target;

            GUILayout.BeginVertical($"SSO LISTENER", "window");

            script.Event = (SSOEvent)EditorGUILayout.ObjectField(script.Event, typeof(SSOEvent), false);
            
            this.serializedObject.Update();
            EditorGUILayout.PropertyField(this.serializedObject.FindProperty("EventTriggered"), true);
            this.serializedObject.ApplyModifiedProperties();

            if (script.Event != null)
            {
                if (!script.Event.Listeners.Contains(script))
                {
                    if (GUILayout.Button("Add Listener"))
                    {
                        script.Event.Add(script);
                    }
                }
            }

            GUILayout.EndVertical();
        }
    }
}
