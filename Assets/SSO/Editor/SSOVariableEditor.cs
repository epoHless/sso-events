using SSO;
using UnityEditor;

[CustomEditor(typeof(SSOVariable<>), true)]
public class SSOVariableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var script = (IScriptableIndex)target;
        script.OnInspectorGUI();
    }
}
