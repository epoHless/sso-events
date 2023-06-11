using UnityEditor;
using UnityEngine;

namespace SSO
{
    [CreateAssetMenu(menuName = "SSO/Variables/Bool Variable", order = 0)]

    public class SSOBoolVariable : SSOVariable<bool>
    {
        public override void OnInspectorGUI()
        {
#if UNITY_EDITOR

            GUILayout.BeginVertical("VALUE", "window");

            Value = EditorGUILayout.Toggle("Value", Value);
            
            GUILayout.EndVertical();

#endif
        }
    }
}