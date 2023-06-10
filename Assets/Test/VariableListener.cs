using SSO;
using UnityEngine;
using UnityEngine.UI;

public class VariableListener : MonoBehaviour
{
    public SSOVariable<float> HP;
    public SSOVariable<bool> Active;
    
    [SerializeField] private Image Image;

    private void OnEnable()
    {
        HP.OnValueChanged += HPOnOnValueChanged;
        Active.OnValueChanged += ActiveOnOnValueChanged;
    }
    
    private void OnDisable()
    {
        HP.OnValueChanged -= HPOnOnValueChanged;
        Active.OnValueChanged -= ActiveOnOnValueChanged;
    }

    private void ActiveOnOnValueChanged(bool _value)
    {
        Image.enabled = _value;
    }

    private void HPOnOnValueChanged(float _value)
    {
        Image.fillAmount = _value / 100;
    }
}
