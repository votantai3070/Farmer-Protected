using Pathfinding;
using System.Collections;
using UnityEngine;

public class BoneController : Enemy
{
    [Header("Bone Controller Setting")]
    private ObjectPool bonePool;
    private SpawnEnemy spawnEnemy;

    protected override void Awake()
    {
        base.Awake();
        bonePool = GameObject.Find("BonePool").GetComponent<ObjectPool>();
        spawnEnemy = FindAnyObjectByType<SpawnEnemy>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        Sprite sprite = GameManager.Instance.characterAtlas.GetSprite("Bones_SingleSkull_Idle_0");
        spriteRenderer.sprite = sprite;
    }

    protected override void Die()
    {
        base.Die();
        StartCoroutine(AnimationDead());
    }

    IEnumerator AnimationDead()
    {
        enemyAnimation.SwitchBoneAnimation("DEAD");
        yield return new WaitForSeconds(1f);

        Transform enemyRoot = transform.parent;

        drop.SetEnemyDropItem(enemyRoot, characterData);

        drop.DropExp3(enemyRoot);

        spawnEnemy.ReturnEnemy(enemyRoot.gameObject, bonePool);
    }
}
