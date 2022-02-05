using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        EnemyRandomMovementController enemy = other.GetComponent<EnemyRandomMovementController>();
        if(player) //identifica si el jugador toca la explosion para eliminar su objeto de la escena
        {
            player.isDead = true;
            Debug.Log("You are dead");
            Destroy(player.gameObject, 1f);
            GameEvent.OnGameOverEvent?.Invoke();
        }
        else if(enemy)
        {
            enemy.isDead = true;
            Destroy(enemy.gameObject);
        }
        else if(other.gameObject.GetComponent<ExtraBomb>())
        {
            Destroy(other.gameObject);
        }
        else if(other.gameObject.GetComponent<SpeedDown>())
        {
            Destroy(other.gameObject);
        }
        else if(other.gameObject.GetComponent<SpeedUp>())
        {
            Destroy(other.gameObject);
        }
    }
}
