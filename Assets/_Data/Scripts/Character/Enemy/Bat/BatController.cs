using System.Collections;
using UnityEngine;

public class BatController : Enemy
{
    [Header("Bat Controller Setting")]
    private ObjectPool batPool;
    private SpawnEnemy spawnEnemy;

    private void Awake()
    {
        batPool = GameObject.Find("BatPool").GetComponent<ObjectPool>();
        spawnEnemy = FindAnyObjectByType<SpawnEnemy>();
    }

    protected override void Die()
    {
        StartCoroutine(AnimationDead());
    }

    IEnumerator AnimationDead()
    {
        enemyAnimation.SwitchBatAnimation("DEAD");
        yield return new WaitForSeconds(1f);
        spawnEnemy.ReturnEnemy(transform.parent.gameObject, batPool);
    }
}
