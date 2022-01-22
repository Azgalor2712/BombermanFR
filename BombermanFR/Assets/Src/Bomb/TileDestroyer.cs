using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileDestroyer : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    [SerializeField] private Tile destructible;
    [SerializeField] private Tile wall;
    [SerializeField] private Tile wall1;
    [SerializeField] private Tile wall2;
    [SerializeField] private Tile wall3;
    [SerializeField] private Tile wall4;



    [SerializeField] private Tilemap tilemap;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Explode(Vector3 position) //controla el rago de la explosion
    {
        Vector3Int explosition = tilemap.WorldToCell(position);
        ExplodeByCell(explosition);
        if(ExplodeByCell(explosition + new Vector3Int(1,0,0)))
        {
            ExplodeByCell(explosition + new Vector3Int(2,0,0));
        }

        if (ExplodeByCell(explosition + new Vector3Int(0,1,0)))
        {
            ExplodeByCell(explosition + new Vector3Int(0,2,0));
        }

        if(ExplodeByCell(explosition + new Vector3Int(-1,0,0)))
        {
            ExplodeByCell(explosition + new Vector3Int(-2,0,0));
        }
        
        if(ExplodeByCell(explosition + new Vector3Int(0,-1,0)))
        {
            ExplodeByCell(explosition + new Vector3Int(0,-2,0));
        }
        
    }

    //genera los prefabs de explosion y devuelve un booleano que controla la ubicacion para esto 
    //según si el objeto es destruible o no
    bool ExplodeByCell(Vector3Int cell) 
    {
        Tile tile = tilemap.GetTile<Tile>(cell);

        if(tile == wall || tile == wall1 || tile == wall2 || tile == wall3 || tile == wall4)
        {
            return false;
        }

        if (tile == destructible)
        {
            tilemap.SetTile(cell, null);
        }

        Vector3 pos = tilemap.GetCellCenterWorld(cell);
        GameObject explosionObject = Instantiate(explosion, pos, Quaternion.identity);
        Destroy(explosionObject, 0.6f); //escojo 0.6 por el framerate de la animacion de explosion
        return true;
    }
}
