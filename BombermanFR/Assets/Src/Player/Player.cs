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
    // Start is called before the first frame update
    void Start()
    {
        movementController = GetComponent<PlayerMovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        Vector2 targetMovementDirection = new Vector2(movementInput.x, movementInput.y);
        targetMovementDirection.Normalize();
        _animator.SetFloat("Horizontal",targetMovementDirection.x);
        _animator.SetFloat("Vertical", targetMovementDirection.y);
        _animator.SetFloat("Speed", targetMovementDirection.sqrMagnitude);
        movementController.Move(targetMovementDirection*speed);

    }

    void ProcessInputs()
    {
        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Input.GetKeyDown (KeyCode.Space))
        {
            DropBomb();
        }
    }

    private void DropBomb()
    {
        Vector3Int cell = tilemap.WorldToCell(transform.position);
        Vector3 cellCenter = tilemap.GetCellCenterWorld(cell);
        if(bombPrefab)
        {
            Instantiate(bombPrefab,cellCenter,Quaternion.identity);
        }
    }
}
