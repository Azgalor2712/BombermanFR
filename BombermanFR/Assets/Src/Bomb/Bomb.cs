using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float countdown = 3f;
    private Collider2D _collider;

    void Start()
    {
        this._collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        _collider.enabled = false; //se desactiva el collider para evitar conflictos que luego encierran al jugador
        if(countdown <= 2)
        {
            this._collider.enabled = true; //se activa el collider despues de cierto tiempo
        }

        if(countdown <= 0)
        {
            FindObjectOfType<TileDestroyer>().Explode(transform.position); //se genera la explosionen el rango determinado
            Destroy(gameObject);
        }
    }
}
