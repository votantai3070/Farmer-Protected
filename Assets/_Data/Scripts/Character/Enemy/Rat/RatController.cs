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
        expPool = GameObject.Find("Exp1Pool").GetComponent<ObjectPool>();
        spawnEnemy = FindAnyObjectByType<SpawnEnemy>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        Sprite sprite = GameManager.Instance.characterAtlas.GetSprite("Rat_Idle_0");
        spriteRenderer.sprite = sprite;
    }

    protected override void Die()
    {
        base.Die();
        StartCoroutine(AnimationDead());
    }

    IEnumerator AnimationDead()
    {
        enemyAnimation.SwitchRatAnimation("DEAD");
        yield return new WaitForSeconds(1f);
        GameObject exp = expPool.Get();
        exp.transform.SetPositionAndRotation(transform.position, transform.rotation);

        spawnEnemy.ReturnEnemy(transform.parent.gameObject, ratPool);
    }
}
