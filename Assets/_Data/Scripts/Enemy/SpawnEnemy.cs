using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [Header("Spawn Enemy Setting")]
    public Transform player;
    public List<EnemyPool> enemyPools = new();
    public float spawnRadius = 20f;
    public int maxEnemies = 5;

    private List<GameObject> activeEnemies = new();
    private void Start()
    {
        InvokeRepeating(nameof(HandleSpawnEnemy), 2f, 3f);
    }


    private void HandleSpawnEnemy()
    {
        if (player == null || enemyPools.Count == 0) return;

        if (activeEnemies.Count >= maxEnemies) return;

        EnemyPool selectedPool = enemyPools[Random.Range(0, enemyPools.Count)];

        GameObject enemy = selectedPool.Get();

        Vector3 spawnPos = GetrRandomPositionNearPlayer();

        enemy.transform.position = spawnPos;

        activeEnemies.Add(enemy);
    }
    private Vector3 GetrRandomPositionNearPlayer()
    {
        Vector3 pos = Random.insideUnitCircle.normalized * spawnRadius;
        return player.position + new Vector3(pos.x, pos.y, 0);
    }
    public void ReturnEnemy(GameObject enemy, EnemyPool pool)
    {
        pool.ReturnPool(enemy);
        activeEnemies.Remove(enemy);
    }
}
