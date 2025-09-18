using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [Header("Spawn Enemy Setting")]
    public Transform player;

    [SerializeField] private List<ObjectPool> enemyPhase1Pools = new();
    [SerializeField] private List<ObjectPool> enemyPhase2Pools = new();
    [SerializeField] private List<ObjectPool> enemyPhase3Pools = new();
    [SerializeField] private List<ObjectPool> enemyPhase4Pools = new();

    [SerializeField] private float spawnRadius = 20f;
    [SerializeField] private int maxEnemiesPhase1 = 5;
    [SerializeField] private int maxEnemiesPhase2 = 5;
    [SerializeField] private int maxEnemiesPhase3 = 5;
    [SerializeField] private int maxEnemiesPhase4 = 5;

    [SerializeField]
    private float phase2Time = 30;
    [SerializeField]
    private float phase3Time = 20;
    [SerializeField]
    private float phase4Time = 10;

    [SerializeField] private float spawnTime;
    ObjectPool pool;
    int maxEnemies;

    private List<GameObject> activeEnemies = new();
    private void Start()
    {
        InvokeRepeating(nameof(HandleSpawnEnemy), 2f, spawnTime);
        maxEnemies = maxEnemiesPhase1;
    }

    private void Update()
    {
        Debug.Log("Max Enemies: " + maxEnemies);
        //Debug.Log("Current Time: " + GameManager.Instance.currentTime);
        //Debug.Log("Start Time: " + GameManager.Instance.startTime);
    }

    void CheckConditionSpawnEnemy()
    {
        if (GameManager.Instance.currentTime < GameManager.Instance.startTime)
        {
            ObjectPool selectedPool = enemyPhase1Pools[Random.Range(0, enemyPhase1Pools.Count)];
            pool = selectedPool;
            maxEnemies = maxEnemiesPhase1;
            Debug.Log("Phase 1");

        }
        else if (GameManager.Instance.currentTime < GameManager.Instance.startTime * phase2Time / 100)
        {
            ObjectPool selectedPool = enemyPhase2Pools[Random.Range(0, enemyPhase2Pools.Count)];
            pool = selectedPool;
            maxEnemies = maxEnemiesPhase2;
            Debug.Log("Phase 2");
        }
        else if (GameManager.Instance.currentTime < GameManager.Instance.startTime * phase3Time / 100)
        {
            ObjectPool selectedPool = enemyPhase3Pools[Random.Range(0, enemyPhase3Pools.Count)];
            pool = selectedPool;
            maxEnemies = maxEnemiesPhase3;
            Debug.Log("Phase 3");

        }
        else if (GameManager.Instance.currentTime < GameManager.Instance.startTime * phase4Time / 100)
        {
            ObjectPool selectedPool = enemyPhase4Pools[Random.Range(0, enemyPhase4Pools.Count)];
            pool = selectedPool;
            maxEnemies = maxEnemiesPhase4;
            Debug.Log("Phase 4");
        }
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

        CheckConditionSpawnEnemy();

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
