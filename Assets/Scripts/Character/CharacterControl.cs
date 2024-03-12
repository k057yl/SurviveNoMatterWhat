using System;
using UnityEngine;
using Zenject;

public class CharacterControl : MonoBehaviour
{
    private const float NORMAL_GRAVITY = 1f;
    private const float FALL_GRAVITY = 2f;
    private const float ZERO = 0f;
    private const float COLLISION_DAMAGE = 10f;
    private const float MAX_HEALTH = 100f;
    private const float SPEED_DEFAULT = 10f;
    
    [Inject] private IInput _input;
    
    [SerializeField] private Rigidbody _rigidbody;

    private Model _model;
    private bool _isGrounded;

    private void Awake()
    {
        _model = new Model(MAX_HEALTH);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 movementInput = _input.MovementInput();
        Vector3 movement = new Vector3(movementInput.x * SPEED_DEFAULT, 0f, movementInput.y * SPEED_DEFAULT);
        _rigidbody.velocity = new Vector3(movement.x, 0f, movement.z);
    }
}
