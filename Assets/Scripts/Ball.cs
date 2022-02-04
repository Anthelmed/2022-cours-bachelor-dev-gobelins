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
        
        var direction = Camera.main.transform.forward;
        direction.y = 0; // Applati le vecteur
        direction.Normalize();
        
        rigidbody.AddForce(direction * force, ForceMode.Impulse);
        
        _holdDuration = 0;
        
        Scene.IncrementClickCount();
    }
}
