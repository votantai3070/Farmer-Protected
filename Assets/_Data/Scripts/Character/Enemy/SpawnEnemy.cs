using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [Header("Spawn Enemy Setting")]
    public Transform player;

    public List<ObjectPool> enemyPhase1Pools = new();
    public List<ObjectPool> enemyPhase2Pools = new();
    public List<ObjectPool> enemyPhase3Pools = new();
    public List<ObjectPool> enemyPhase4Pools = new();

    public float spawnRadius = 20f;
    public int maxEnemies = 5;

    bool spawn100, spawn50, spawn30, spawn15;
    ObjectPool pool;

    private List<GameObject> activeEnemies = new();
    private void Start()
    {
        InvokeRepeating(nameof(HandleSpawnEnemy), 2f, 3f);
    }


    private void HandleSpawnEnemy()
    {
        if (player == null
            && enemyPhase1Pools.Count == 0
            && enemyPhase2Pools.Count == 0
            && enemyPhase3Pools.Count == 0
            && enemyPhase4Pools.Count == 0)
            return;

        if (activeEnemies.Count >= maxEnemies) return;

        if (!spawn100 && GameManager.Instance.currentTime < GameManager.Instance.startTime)
        {
            spawn100 = true;
            ObjectPool selectedPool = enemyPhase1Pools[Random.Range(0, enemyPhase1Pools.Count)];
            pool = selectedPool;
        }
        else if (!spawn50 && GameManager.Instance.currentTime < GameManager.Instance.startTime * 0.5)
        {
            spawn50 = true;
            ObjectPool selectedPool = enemyPhase2Pools[Random.Range(0, enemyPhase2Pools.Count)];
            pool = selectedPool;
        }
        else if (!spawn30 && GameManager.Instance.currentTime < GameManager.Instance.startTime * 0.3)
        {
            spawn30 = true;
            ObjectPool selectedPool = enemyPhase3Pools[Random.Range(0, enemyPhase3Pools.Count)];
            pool = selectedPool;
        }
        else if (!spawn15 && GameManager.Instance.currentTime < GameManager.Instance.startTime * 0.15)
        {
            spawn15 = true;
            ObjectPool selectedPool = enemyPhase4Pools[Random.Range(0, enemyPhase4Pools.Count)];
            pool = selectedPool;
        }

        GameObject enemy = pool.Get();

        Vector3 spawnPos = GetRandomPositionNearPlayer();

        enemy.transform.position = spawnPos;

        activeEnemies.Add(enemy);
    }

    private Vector3 GetRandomPositionNearPlayer()
    {
        Vector3 pos = Random.insideUnitCircle.normalized * spawnRadius;
        return player.position + new Vector3(pos.x, pos.y, 0);
    }

    public void ReturnEnemy(GameObject enemy, ObjectPool pool)
    {
        pool.ReturnPool(enemy);
        activeEnemies.Remove(enemy);
    }


}
