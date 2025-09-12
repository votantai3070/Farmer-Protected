using System.Collections;
using UnityEngine;

public class GolemControler : Enemy
{
    [Header("Golem Controller Setting")]
    private ObjectPool golemPool;
    private SpawnEnemy spawnEnemy;

    private void Awake()
    {
        golemPool = GameObject.Find("GolemPool").GetComponent<ObjectPool>();
        spawnEnemy = FindAnyObjectByType<SpawnEnemy>();
    }
    protected override void Die()
    {
        StartCoroutine(AnimationDead());
    }

    IEnumerator AnimationDead()
    {
        enemyAnimation.SwitchGolemAnimation("DEAD");
        yield return new WaitForSeconds(1f);
        spawnEnemy.ReturnEnemy(transform.parent.gameObject, golemPool);
    }
}
