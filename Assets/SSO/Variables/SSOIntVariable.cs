using UnityEngine;

namespace SSO
{

    [CreateAssetMenu(fileName = "New Int Variable", menuName = "SSO/Variables/Int Variable", order = 0)]
    public class SSOIntVariable : SSOVariable<int>
    {
        [SerializeField] private int value;

        public override int Value
        {
            get => this.value;
            set
            {
                this.value = value;
                TriggerValueChanged();
            }
        }
    }

}