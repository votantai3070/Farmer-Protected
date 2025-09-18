using Pathfinding;
using System.Collections;
using UnityEngine;

public class GolemControler : Enemy
{
    [Header("Golem Controller Setting")]
    private ObjectPool golemPool;
    private SpawnEnemy spawnEnemy;

    protected override void Awake()
    {
        base.Awake();
        golemPool = GameObject.Find("GolemPool").GetComponent<ObjectPool>();
        spawnEnemy = FindAnyObjectByType<SpawnEnemy>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        Sprite sprite = GameManager.Instance.characterAtlas.GetSprite("Golem_IdleB_0");
        spriteRenderer.sprite = sprite;
    }
    protected override void Die()
    {
        base.Die();
        StartCoroutine(AnimationDead());
    }

    IEnumerator AnimationDead()
    {
        enemyAnimation.SwitchGolemAnimation("DEAD");
        yield return new WaitForSeconds(1f);

        Transform enemyRoot = transform.parent;

        drop.SetEnemyDropItem(enemyRoot, characterData);

        drop.DropExp3(enemyRoot);

        spawnEnemy.ReturnEnemy(enemyRoot.gameObject, golemPool);
    }
}
