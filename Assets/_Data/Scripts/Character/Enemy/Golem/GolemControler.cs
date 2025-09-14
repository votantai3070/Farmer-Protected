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
        expPool = GameObject.Find("Exp3Pool").GetComponent<ObjectPool>();
        spawnEnemy = FindAnyObjectByType<SpawnEnemy>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        Sprite sprite = spriteAtlas.GetSprite("Golem_IdleB_0");
        spriteRenderer.sprite = sprite;
    }
    protected override void Die()
    {
        StartCoroutine(AnimationDead());
    }

    IEnumerator AnimationDead()
    {
        enemyAnimation.SwitchGolemAnimation("DEAD");
        yield return new WaitForSeconds(1f);
        GameObject exp = expPool.Get();
        exp.transform.SetPositionAndRotation(transform.position, transform.rotation);
        spawnEnemy.ReturnEnemy(transform.parent.gameObject, golemPool);
    }
}
