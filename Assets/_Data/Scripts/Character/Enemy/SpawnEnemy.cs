using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [Header("Spawn Enemy Setting")]
    public Transform player;
    [SerializeField] private DifficultData defaultDiffData;

    [SerializeField] private List<ObjectPool> enemyPhase1Pools = new();
    [SerializeField] private List<ObjectPool> enemyPhase2Pools = new();
    [SerializeField] private List<ObjectPool> enemyPhase3Pools = new();
    [SerializeField] private List<ObjectPool> enemyPhase4Pools = new();


    [SerializeField] private float spawnRadius;
    [SerializeField] private int maxEnemiesPhase1;
    [SerializeField] private int maxEnemiesPhase2;
    [SerializeField] private int maxEnemiesPhase3;
    [SerializeField] private int maxEnemiesPhase4;

    [SerializeField]
    private float phase1Time;
    [SerializeField]
    private float phase2Time;
    [SerializeField]
    private float phase3Time;

    [SerializeField] private float spawnTime;

    ObjectPool pool;
    [SerializeField] int maxEnemies;
    [SerializeField] int startTime;

    private List<GameObject> activeEnemies = new();
    private void Start()
    {
        StartCoroutine(Wait());

        InvokeRepeating(nameof(HandleSpawnEnemy), 2f, spawnTime);
    }

    IEnumerator Wait()
    {
        yield return null;
        if (GameManager.Instance.currentDifficultData != null)
        {
            SetDifficulty(GameManager.Instance.currentDifficultData);
            GameManager.Instance.currentTime = startTime;
        }
        else
        {
            Debug.LogWarning("No difficulty selected, fallback to Easy");
        }
    }

    private void Update()
    {
        GameManager.Instance.ShowTime(startTime);
    }

    void CheckConditionSpawnEnemy()
    {
        float currentTime = GameManager.Instance.currentTime;

        float phase1Start = startTime * phase1Time;
        float phase2Start = startTime * phase2Time;
        float phase3Start = startTime * phase3Time;

        if (currentTime > phase1Start)
        {
            ObjectPool selectedPool = enemyPhase1Pools[Random.Range(0, enemyPhase1Pools.Count)];
            pool = selectedPool;
            maxEnemies = maxEnemiesPhase1;
            Debug.Log("Phase 1");

        }
        else if (currentTime > phase2Start)
        {
            ObjectPool selectedPool = enemyPhase2Pools[Random.Range(0, enemyPhase2Pools.Count)];
            pool = selectedPool;
            maxEnemies = maxEnemiesPhase2;
            Debug.Log("Phase 2");
        }
        else if (currentTime > phase3Start)
        {
            ObjectPool selectedPool = enemyPhase3Pools[Random.Range(0, enemyPhase3Pools.Count)];
            pool = selectedPool;
            maxEnemies = maxEnemiesPhase3;
            Debug.Log("Phase 3");

        }
        else
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
        Debug.Log("Chay vo");

        CheckConditionSpawnEnemy();

        GameObject enemy = pool.Get();

        Debug.Log(enemy);

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

    void SetDifficulty(DifficultData difficultData)
    {
        Debug.Log("Set Difficulty: " + difficultData.difficult);
        //enemyPhase1Pools = difficultData.enemyPhase1;
        //enemyPhase2Pools = difficultData.enemyPhase2;
        //enemyPhase3Pools = difficultData.enemyPhase3;
        //enemyPhase4Pools = difficultData.enemyPhase4;

        maxEnemies = difficultData.phase1EnemyCount;

        maxEnemiesPhase1 = difficultData.phase1EnemyCount;
        maxEnemiesPhase2 = difficultData.phase2EnemyCount;
        maxEnemiesPhase3 = difficultData.phase3EnemyCount;
        maxEnemiesPhase4 = difficultData.phase4EnemyCount;

        startTime = difficultData.timeCountdown;

        phase1Time = difficultData.phase1Time;
        phase2Time = difficultData.phase2Time;
        phase3Time = difficultData.phase3Time;
    }
}
