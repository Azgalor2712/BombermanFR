using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private EnemyRandomMovementController enemy1;
    [SerializeField] private EnemyRandomMovementController enemy2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown (KeyCode.Space))
        {
            GameEvent.OnGameStartEvent?.Invoke();
        }
        if(enemy1.isDead && enemy2.isDead)
        {
            Debug.Log("You win!");
            GameEvent.OnGameOverEvent?.Invoke();
        }
    }
}
