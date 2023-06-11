using SSO;
using UnityEngine;
using UnityEngine.UI;

public class VariableListener : MonoBehaviour
{
    public SSOFloatRange HP;
    public SSOVariable<bool> Active;
    
    [SerializeField] private Image Image;

    private void Start()
    {
        HP.Value = HP.MaxValue;
        Image.fillAmount = HP.MaxValue / 100;
    }

    private void OnEnable()
    {
        HP.OnValueChanged.AddListener(HPOnOnValueChanged);
        HP.OnMaxValueChanged += HPOnOnValueChanged;
        
        HP.OnMinValueReached += OnMinValueReached;
        
        Active.OnValueChanged.AddListener(ActiveOnOnValueChanged);
    }

    private void OnMinValueReached()
    {
        Debug.Log("YOU DIED!");
    }

    private void OnDisable()
    {
        HP.OnValueChanged.RemoveListener(HPOnOnValueChanged);
        Active.OnValueChanged.RemoveListener(ActiveOnOnValueChanged);
    }

    private void ActiveOnOnValueChanged(bool _value)
    {
        Image.enabled = _value;
    }

    private void HPOnOnValueChanged(float _value)
    {
        Image.fillAmount = _value / HP.MaxValue;
    }
}
