using System;
using SSO;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "SSO/Variables/Float Range Variable", order = 0)]
public class SSOFloatRange : SSOVariable<float>
{
    public Action<float> OnMaxValueChanged;
    public Action<float> OnMinValueChanged;
    
    public Action OnMaxValueReached;
    public Action OnMinValueReached;

    public override float Value
    {
        get => value;
        set
        {
            this.value = value;
            
            CallOnValueChanged(value);

            if (this.value > maxValue)
            {
                this.value = maxValue;
                OnMaxValueReached?.Invoke();
            }
            else if (this.value < minValue)
            {
                this.value = minValue;
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

        GUILayout.BeginHorizontal();

        MinValue = EditorGUILayout.FloatField("", MinValue, GUILayout.Width(40));
        Value = EditorGUILayout.Slider(Value, MinValue, MaxValue);
        MaxValue = EditorGUILayout.FloatField("", MaxValue, GUILayout.Width(40));

        GUILayout.EndHorizontal();
        
        GUILayout.EndVertical();

#endif
    }
}
