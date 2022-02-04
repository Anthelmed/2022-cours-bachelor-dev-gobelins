using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody; // bonne version
    public Vector2 minMaxForce = new Vector2(5f, 20f);
    public float maxHoldDuration = 3f;

    private float _holdDuration;

    private void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            _holdDuration = math.min(_holdDuration + Time.deltaTime, maxHoldDuration); // nouveau package de math
            //_holdDuration = Mathf.Min(_holdDuration + Time.deltaTime, maxHoldDuration);
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame)
            Throw();
    }

    private void Throw()
    {
        var force = math.lerp(minMaxForce.x, minMaxForce.y, _holdDuration / maxHoldDuration);
        
        rigidbody.AddForce(rigidbody.transform.forward * force);
        
        _holdDuration = 0;
    }
}
