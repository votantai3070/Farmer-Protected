using System.Collections;
using UnityEngine;

public class RatController : Enemy
{
    [Header("Rat Controller Setting")]
    private ObjectPool ratPool;
    private SpawnEnemy spawnEnemy;

    private void Awake()
    {
        ratPool = GameObject.Find("RatPool").GetComponent<ObjectPool>();
        spawnEnemy = FindAnyObjectByType<SpawnEnemy>();
    }
    protected override void Die()
    {
        StartCoroutine(AnimationDead());
    }

    IEnumerator AnimationDead()
    {
        enemyAnimation.SwitchRatAnimation("DEAD");
        yield return new WaitForSeconds(1f);
        spawnEnemy.ReturnEnemy(transform.parent.gameObject, ratPool);
    }
}
