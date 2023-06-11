using UnityEditor;
using UnityEngine;

namespace SSO.Events.Editor
{
    [CustomEditor(typeof(SSOListener))]
    public class SSOListenerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var script = (SSOListener)target;

            var message = script.Event ? $"LISTENING TO {script.Event.name.ToUpper()}" : "MISSING EVENT";
            
            var baseColor = GUI.color;
            GUI.color = script.Event ? Color.green : Color.red;
            GUILayout.BeginVertical(message, "window");
            GUI.color = baseColor;
            
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
