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
        if(player) //identifica si el jugador toca la explosion para eliminar su objeto de la escena
        {
            player.isDead = true;
            Debug.Log("You are dead");
            Destroy(player.gameObject, 1f);
            GameEvent.OnGameOverEvent?.Invoke();
        }
    }
}
