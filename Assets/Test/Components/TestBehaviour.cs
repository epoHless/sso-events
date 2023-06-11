using UnityEngine;

public class TestBehaviour : MonoBehaviour
{
    public void Test(int value){ Debug.Log($"{gameObject.name} is listening with a value of {value}!"); }
}
