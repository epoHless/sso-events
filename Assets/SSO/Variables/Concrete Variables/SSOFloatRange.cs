using System;
using SSO;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "SSO/Variables/Float Range Variable", order = 0)]
public class SSOFloatRange : SSOFloatVariable
{
    public Action<float> OnMaxValueChanged;
    public Action<float> OnMinValueChanged;
    
    public Action OnMaxValueReached;
    public Action OnMinValueReached;

    private SSOFloatVariable FloatVariable;
    
    public override float Value
    {
        get => FloatVariable.Value;
        set
        {
            FloatVariable.Value = value;
            
            FloatVariable.OnValueChanged?.Invoke(FloatVariable.Value);

            if (FloatVariable.Value > maxValue)
            {
                FloatVariable.Value = maxValue;
                OnMaxValueReached?.Invoke();
            }
            else if (FloatVariable.Value < minValue)
            {
                FloatVariable.Value = minValue;
                OnMinValueReached?.Invoke();
            }
        } 
    }

    private float maxValue;
    public float MaxValue
    {
        get => maxValue;
        set
        {
            maxValue = value;
            OnMaxValueChanged?.Invoke(value);
        }
    }
    
    private float minValue;
    public float MinValue
    {
        get => minValue;
        set
        {
            minValue = value;
            OnMinValueChanged?.Invoke(value);
        }
    }

    public override void OnInspectorGUI()
    {
#if UNITY_EDITOR
            
        GUILayout.BeginVertical("VALUE", "window");

        FloatVariable = (SSOFloatVariable)EditorGUILayout.ObjectField(FloatVariable, typeof(SSOFloatVariable), false);
        
        GUILayout.BeginHorizontal();

        if (!FloatVariable)
        {
            EditorGUILayout.HelpBox("Add a Float Variable in order to start modifying the values", MessageType.Error);
        }
        else
        {
            MinValue = EditorGUILayout.FloatField("", MinValue, GUILayout.Width(40));
            Value = EditorGUILayout.Slider(Value, MinValue, MaxValue);
            MaxValue = EditorGUILayout.FloatField("", MaxValue, GUILayout.Width(40));
        }

        GUILayout.EndHorizontal();
        
        GUILayout.EndVertical();

#endif
    }
}
