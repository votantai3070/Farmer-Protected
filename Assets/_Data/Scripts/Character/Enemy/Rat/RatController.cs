using System.Collections;
using UnityEngine;

public class RatController : Enemy
{
    [Header("Rat Controller Setting")]
    private ObjectPool ratPool;
    private SpawnEnemy spawnEnemy;

    protected override void Awake()
    {
        base.Awake();
        ratPool = GameObject.Find("RatPool").GetComponent<ObjectPool>();
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

        Transform enemyRoot = transform.parent;

        drop.SetEnemyDropItem(enemyRoot, characterData);

        drop.DropExp1(enemyRoot);

        spawnEnemy.ReturnEnemy(enemyRoot.gameObject, ratPool);
    }
}
