using UnityEngine;

public class BatController : Enemy
{
    [Header("Bat Controller Setting")]
    private EnemyPool batPool;
    private SpawnEnemy spawnEnemy;

    private void Awake()
    {
        batPool = GameObject.Find("BatPool").GetComponent<EnemyPool>();
        spawnEnemy = FindAnyObjectByType<SpawnEnemy>();
    }

    protected override void Die()
    {
        spawnEnemy.ReturnEnemy(gameObject, batPool);
    }
}
