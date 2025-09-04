using System.Collections;
using UnityEngine;

public class BatController : Enemy
{
    [Header("Bat Controller Setting")]
    private EnemyPool batPool;
    private SpawnEnemy spawnEnemy;
    public EnemyAnimation batAnimation;

    private void Awake()
    {
        batPool = GameObject.Find("BatPool").GetComponent<EnemyPool>();
        spawnEnemy = FindAnyObjectByType<SpawnEnemy>();
    }

    protected override void Die()
    {
        StartCoroutine(AnimationDead());
    }

    IEnumerator AnimationDead()
    {
        batAnimation.SwitchBatAnimation("DEAD");
        yield return new WaitForSeconds(1f);
        spawnEnemy.ReturnEnemy(gameObject, batPool);
    }
}
