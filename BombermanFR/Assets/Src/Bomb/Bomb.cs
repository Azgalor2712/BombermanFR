using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float countdown = 5f;
    public Collider2D _collider;

    void Start()
    {
        this._collider = GetComponent<Collider2D>();
        this._collider.enabled = false; //la bomba es instanciada con el collider apagado para evitar conflictos con el jugador
    }

    void Update()
    {
        countdown -= Time.deltaTime;

        if(countdown <= 0)
        {
            GameEvent.OnBombExplode?.Invoke(transform.position); //se genera la explosion en el rango determinado
            Destroy(gameObject);
        }
    }
}
