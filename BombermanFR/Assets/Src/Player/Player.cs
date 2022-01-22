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
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private Animator _animator;

    void Start()
    {
        movementController = GetComponent<PlayerMovementController>();
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
            Instantiate(bombPrefab,cellCenter,Quaternion.identity);
        }
    }
}
