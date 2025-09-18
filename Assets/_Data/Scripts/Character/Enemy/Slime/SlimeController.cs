using Pathfinding;
using System.Collections;
using UnityEngine;

public class SlimeController : Enemy
{
    public EnemyAnimation slimeAnimation;
    private ObjectPool slimePool;
    private SpawnEnemy spawnEnemy;

    protected override void Awake()
    {
        base.Awake();
        slimePool = GameObject.Find("SlimePool").GetComponent<ObjectPool>();
        spawnEnemy = FindAnyObjectByType<SpawnEnemy>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        Sprite sprite = GameManager.Instance.characterAtlas.GetSprite("Slime_Spiked_Idle_0");
        spriteRenderer.sprite = sprite;
    }

    protected override void Die()
    {
        base.Die();
        StartCoroutine(AnimationDead());
    }

    IEnumerator AnimationDead()
    {
        slimeAnimation.SwitchSlimeAnimation("DEAD");
        yield return new WaitForSeconds(1f);

        Transform enemyRoot = transform.parent;

        drop.SetEnemyDropItem(enemyRoot, characterData);

        drop.DropExp1(enemyRoot);

        spawnEnemy.ReturnEnemy(enemyRoot.gameObject, slimePool);
    }
}
