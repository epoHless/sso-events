using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CollisionDamage : MonoBehaviour
{
    [SerializeField] private SSOFloatRange HP;
    private BoxCollider2D _collider2D;

    private void Awake()
    {
        _collider2D = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HP.Value -= 10;
    }
}
