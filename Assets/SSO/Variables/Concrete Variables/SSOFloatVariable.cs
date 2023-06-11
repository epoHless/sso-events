using SSO;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "SSO/Variables/Float Variable", order = 0)]
public class SSOFloatVariable : SSOVariable<float>
{
    public override void OnInspectorGUI()
    {
#if UNITY_EDITOR

        GUILayout.BeginVertical("VALUE", "window");

        Value = EditorGUILayout.FloatField("Value", Value);
            
        GUILayout.EndVertical();

#endif
    }
}
