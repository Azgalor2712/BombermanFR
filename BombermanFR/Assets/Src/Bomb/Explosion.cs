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
        if(other.GetComponent<Player>()) //identifica si el jugador toca la explosion para eliminar su objeto de la escena
        {
            Debug.Log("You are dead");
            Destroy(other.gameObject);
        }
    }
}
