using System.Collections;
using UnityEngine;

public class SlimeController : Enemy
{
    public EnemyAnimation slimeAnimation;
    private ObjectPool slimePool;
    private SpawnEnemy spawnEnemy;

    private void Awake()
    {
        slimePool = GameObject.Find("SlimePool").GetComponent<ObjectPool>();
        spawnEnemy = FindAnyObjectByType<SpawnEnemy>();
    }

    protected override void Die()
    {
        StartCoroutine(AnimationDead());
    }

    IEnumerator AnimationDead()
    {
        slimeAnimation.SwitchSlimeAnimation("DEAD");
        yield return new WaitForSeconds(1f);
        spawnEnemy.ReturnEnemy(transform.parent.gameObject, slimePool);
    }

}
