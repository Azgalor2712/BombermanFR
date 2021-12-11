using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float countdown = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0)
        {
            FindObjectOfType<TileDestroyer>().Explode(transform.position);
            Destroy(gameObject);
        }
    }
}
