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
    [SerializeField] private Player player;
    [SerializeField] private ExtraBomb extraBombPrefab;
    [SerializeField] private SpeedUp speedUpPrefab;
    [SerializeField] private SpeedDown speedDownPrefab;

    void Start()
    {
        GameEvent.OnBombExplode += OnBombExplode;
        GameEvent.OnPowerUpSpawn += OnPowerUpSpawn;
    }

    void Update()
    {
        
    }

    void OnDestroy()
    {
        GameEvent.OnBombExplode -= OnBombExplode;
        GameEvent.OnPowerUpSpawn -= OnPowerUpSpawn;
    }

    public void OnBombExplode(Vector3 position) //controla el rago de la explosion
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
        player.bombs += 1;
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
            OnPowerUpSpawn(cell);
        }

        Vector3 pos = tilemap.GetCellCenterWorld(cell);
        GameObject explosionObject = Instantiate(explosion, pos, Quaternion.identity);
        Destroy(explosionObject, 0.6f); //escojo 0.6 por el framerate de la animacion de explosion
        return true;
    }

    void OnPowerUpSpawn(Vector3Int position)
    {
        if(Random.Range(1f, 100f) < 30f)
        {
            Vector3 pos = tilemap.GetCellCenterWorld(position);
            Instantiate(extraBombPrefab,pos,Quaternion.identity);
        }

        else if(Random.Range(1f, 100f) < 10f)
        {
            Vector3 pos = tilemap.GetCellCenterWorld(position);
            Instantiate(speedUpPrefab,pos,Quaternion.identity);
        }

        else if(Random.Range(1f, 100f) < 40f)
        {
            Vector3 pos = tilemap.GetCellCenterWorld(position);
            Instantiate(speedDownPrefab,pos,Quaternion.identity);
        }
    }
}
