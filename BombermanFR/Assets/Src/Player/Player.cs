using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private float speed = 5f;
    private PlayerMovementController movementController;
    private Vector2 movementInput;
    GameObject bomb;
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private Animator _animator;
    public bool isDead = false;

    void Start()
    {
        movementController = GetComponent<PlayerMovementController>();
        _animator.SetBool("isDead", isDead);
    }


    void Update()
    {
        ProcessInputs();
        Vector2 targetMovementDirection = new Vector2(movementInput.x, movementInput.y);
        targetMovementDirection.Normalize();
        //animacion de movimiento
        _animator.SetFloat("Horizontal",targetMovementDirection.x);
        _animator.SetFloat("Vertical", targetMovementDirection.y);
        _animator.SetFloat("Speed", targetMovementDirection.sqrMagnitude);
        //movimiento
        movementController.Move(targetMovementDirection*speed);
        CheckBombPosition();
        _animator.SetBool("isDead", isDead);
    }

    void ProcessInputs() //como el nombre dice, proceso los inputs del player
    {
        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Input.GetKeyDown (KeyCode.Space))
        {
            DropBomb();
        }
    }

    private void DropBomb() //se usa para que el jugador pueda poner bombas al presionar espacio
    {
        Vector3Int cell = tilemap.WorldToCell(transform.position);
        Vector3 cellCenter = tilemap.GetCellCenterWorld(cell);
        if(bombPrefab)
        {
            bomb = Instantiate(bombPrefab,cellCenter,Quaternion.identity);
        }
    }

    void CheckBombPosition() //checa la posicion de la bomba para saber cuando activar el collider
    {
        if(bomb != null)
        {
            Vector3Int cell = tilemap.WorldToCell(transform.position);
            Vector3Int bombCell = tilemap.WorldToCell(bomb.transform.position);
            if(cell != bombCell)
            {
                bomb.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }
}
