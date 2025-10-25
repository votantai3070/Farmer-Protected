using Pathfinding;
using System.Collections;
using UnityEngine;

public class BatController : Enemy
{
    [Header("Bat Controller Setting")]
    private ObjectPool batPool;
    private SpawnEnemy spawnEnemy;

    protected override void Awake()
    {
        base.Awake();
        batPool = GameObject.Find("BatPool").GetComponent<ObjectPool>();
        spawnEnemy = FindAnyObjectByType<SpawnEnemy>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void Start()
    {
        Sprite sprite = GameManager.Instance.characterAtlas.GetSprite("Bat_Fly_0");
        spriteRenderer.sprite = sprite;
    }

    protected override void Die()
    {
        base.Die();
        StartCoroutine(AnimationDead());
    }

    IEnumerator AnimationDead()
    {
        enemyAnimation.SwitchBatAnimation("DEAD");
        yield return new WaitForSeconds(1f);

        Transform enemyRoot = transform.parent;

        drop.SetEnemyDropItem(enemyRoot, characterData);

        drop.DropExp2(enemyRoot);

        spawnEnemy.ReturnEnemy(enemyRoot.gameObject, batPool);
    }
}
