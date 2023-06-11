using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace SSO
{
    [CustomEditor(typeof(SSOEvent))]
    public class SSOEventEditor : Editor
    {
        private GUIStyle labelStyle;

        private void OnEnable()
        {
            labelStyle = new GUIStyle()
            {
                alignment = TextAnchor.MiddleCenter,
                normal = new GUIStyleState()
                {
                    textColor = ((SSOEvent)target).ListenersCount == 0 ? Color.red : Color.green,
                }
            };
        }

        public override void OnInspectorGUI()
        {
            var script = (SSOEvent)target;
            
            GUILayout.BeginVertical($"There are {script.ListenersCount} Listeners", "window");
            
            if(script.ListenersCount > 0) 
                EditorGUILayout.HelpBox("In order to raise events from editor event calls must be set to 'editor and runtime' in SSOListener", MessageType.Info);

            for (int i = 0; i < script.ListenersCount; i++)
            {
                GUILayout.BeginHorizontal();

                GUI.enabled = false;
                var listener = EditorGUILayout.ObjectField(script.Listeners[i], typeof(SSOListener), true);
                GUI.enabled = true;
                
                if (GUILayout.Button("-", GUILayout.Width(18), GUILayout.Height(18)))
                {
                    script.Remove(script.Listeners[i]);
                }
                
                GUILayout.EndHorizontal();
            }

            GUILayout.BeginHorizontal();
            
            if (GUILayout.Button("Raise Event"))
            {
                script.TriggerEvent();
            }

            
            if (GUILayout.Button("Add All Listeners"))
            {
                var listeners = FindObjectsOfType<SSOListener>().Where(_listener => _listener.Event == script);

                foreach (var listener in listeners)
                {
                    script.Add(listener);
                }
            }

            GUILayout.EndHorizontal();
            
            GUILayout.EndVertical();
        }
    }
}
