using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvent
{
    public delegate void BombExplodeEvent (Vector3 position);
    public static BombExplodeEvent OnBombExplode;
    public delegate void PowerUpSpawnEvent (Vector3Int position);
    public static PowerUpSpawnEvent OnPowerUpSpawn;
}
