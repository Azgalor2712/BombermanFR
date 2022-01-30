using UnityEngine;

public class EnemyRandomMovementController : MonoBehaviour
{
    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 3f;
    [SerializeField] private float characterVelocity = 2f;
    [SerializeField] private Animator _animator;
    private Vector2 movementDirection;
    private Vector2 velocity;


    void Start()
    {
        latestDirectionChangeTime = 0f;
        calculateNewMovementVector();
    }

    void calculateNewMovementVector()
    {
        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
        bool randomDirection = (Random.value > 0.5f);
        if (randomDirection) {
            movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), 0).normalized; //Moving towards x axis
        }
        else
        {
            movementDirection = new Vector2(0, Random.Range(-1.0f, 1.0f)).normalized; //Moving towards y axis
        }
        
        velocity = movementDirection * characterVelocity;
    }

    void Update()
    {
        //if the changeTime was reached, calculate a new movement vector
        if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            calculateNewMovementVector();
        }
        Move(velocity);
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
        Debug.LogError("Entro colision!!!");
        latestDirectionChangeTime = Time.time;
        calculateNewMovementVector();
        Move(velocity);
    }
}
