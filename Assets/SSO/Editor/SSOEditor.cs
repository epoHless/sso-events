using UnityEditor;
using UnityEngine;

namespace SSO
{

    public class SSOEditor
    {
        [MenuItem("SSO/Create Int")]
        public static void CreateAsset()
        {
            var _intVariable = ScriptableObject.CreateInstance<SSOIntVariable>();
            AssetDatabase.CreateAsset(_intVariable, "Assets/Test/int.asset");
        }
    }

}