using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvent
{
    public delegate void BombExplodeEvent (Vector3 position);
    public static BombExplodeEvent OnBombExplode;
    public delegate void PowerUpSpawnEvent (Vector3Int position);
    public static PowerUpSpawnEvent OnPowerUpSpawn;
    public delegate void GameStartAction();
    public static GameStartAction OnGameStartEvent;
    public delegate void GameOverAction();
    public static GameOverAction OnGameOverEvent;
}
