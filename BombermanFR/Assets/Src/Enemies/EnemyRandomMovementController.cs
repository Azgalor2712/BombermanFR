using UnityEngine;

public class EnemyRandomMovementController : MonoBehaviour
{
    private Vector2 initialPosition;
    private bool colissionDetected;

    [SerializeField] private float characterVelocity = 2f;
    [SerializeField] private Animator _animator;
    private Vector2[] movementDirections = new Vector2[4];
    private Vector2 actualMovementDirection;



    void Start()
    {
        movementDirections[0] = new Vector2(0, 1).normalized; // Right
        movementDirections[1] = new Vector2(-1, 0).normalized; // Left
        movementDirections[2] = new Vector2(0, 1).normalized; // Up
        movementDirections[3] = new Vector2(0, -1).normalized; // Down
        initialPosition = transform.position;
    }

    void Update()
    {
        if (((Vector2)transform.position - initialPosition).magnitude <= 0.01)
        {
            Debug.Log("Entro");
            actualMovementDirection = movementDirections[Random.Range(0, 4)];
            Move(actualMovementDirection * characterVelocity);
        }
        if (colissionDetected && ((Vector2)transform.position - initialPosition).magnitude >= 0.01)
        {
            Move(-actualMovementDirection * characterVelocity);
            if (((Vector2)transform.position - initialPosition).magnitude <= 0.01)
            {
                colissionDetected = false;
            }
        }
        if (!colissionDetected && ((Vector2)transform.position - initialPosition).magnitude >= 0.01)
        {
            Move(actualMovementDirection * characterVelocity);
        }

    }

    private void Move(Vector2 velocity)
    {
        //move enemy: 
        transform.position = ((Vector2)transform.position) + (velocity * Time.deltaTime);
        _animator.SetFloat("Horizontal", transform.position.x);
        _animator.SetFloat("Vertical", transform.position.y);
        _animator.SetFloat("Speed", transform.position.sqrMagnitude);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        colissionDetected = true;
    }
}
