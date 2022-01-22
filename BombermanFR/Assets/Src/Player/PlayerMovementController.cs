using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private Rigidbody2D _rb;
    
    private Vector2 _targetVelocity;
    private Quaternion _targetRotation;
    private float _targetRotationSpeed;

    public void Move(Vector2 velocity)
    {
        _targetVelocity = velocity;
    }

    public void RotateTo(Quaternion rotation, float rotationSpeed)
    {
        _targetRotation = rotation;
        _targetRotationSpeed = rotationSpeed;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        _rb.velocity = _targetVelocity; //cambia la velocidad a partir de los inputs procesadoss
    }
}
