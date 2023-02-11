using UnityEditor;
using UnityEngine;

namespace SSO.Editor
{

    public class SSOCreationEditorWindow : EditorWindow
    {
        private string path;
        
        [MenuItem("SSO/Variables/Create Int Variable")]
        private static void ShowWindow()
        {
            var window = GetWindow<SSOCreationEditorWindow>();
            window.titleContent = new GUIContent("SSO Creation");
            window.Show();
        }

        private void OnGUI()
        {
            path = GUILayout.TextField(path);
            
            if (GUILayout.Button("Create Int Variable"))
            {
                SSOVariable<int> _intVariable = ScriptableObject.CreateInstance<SSOVariable<int>>();
                AssetDatabase.CreateAsset(_intVariable, path);
            }
        }
    }

}