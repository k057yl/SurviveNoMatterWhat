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

    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravityForce;
    [SerializeField] private float _rayDistance;
    
    [Inject] private IInput _input;
    
    private Transform _spawnPoint;
    private Rigidbody _rigidbody;

    private Model _model;
    private bool _isGrounded;

    [Inject]
    public void Initialize(Transform spawnPoint)
    {
        _spawnPoint = spawnPoint;
    }

    private void Awake()
    {
        transform.position = _spawnPoint.position;
        _rigidbody = GetComponent<Rigidbody>();
        _model = new Model(MAX_HEALTH);
    }

    private void FixedUpdate()
    {
        Move();
        ApplyGravity();
    }
    
    private void Update()
    {
        if (_input.IsJumping() && IsGrounded())
        {
            Jump();
        }
    }

    private void Move()
    {
        Vector2 movementInput = _input.MovementInput();
        Vector3 movement = new Vector3(movementInput.x * SPEED_DEFAULT, 0f, movementInput.y * SPEED_DEFAULT);
        _rigidbody.velocity = new Vector3(movement.x, 0f, movement.z);
    }
    
    private bool IsGrounded()
    {
        float rayLength = _rayDistance;
        
        Ray ray = new Ray(transform.position, Vector3.down);
        
        if (Physics.Raycast(ray, rayLength))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    private void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }
    
    private void ApplyGravity()
    {
        if (!IsGrounded())
        {
            _rigidbody.AddForce(Vector3.down * _gravityForce, ForceMode.Acceleration);
        }
    }
}
