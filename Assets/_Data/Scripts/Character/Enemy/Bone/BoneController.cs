using System.Collections;
using UnityEngine;

public class BoneController : Enemy
{
    [Header("Bone Controller Setting")]
    private ObjectPool bonePool;
    private SpawnEnemy spawnEnemy;

    private void Awake()
    {
        bonePool = GameObject.Find("BonePool").GetComponent<ObjectPool>();
        expPool = GameObject.Find("Exp2Pool").GetComponent<ObjectPool>();
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
        GameObject exp = expPool.Get();
        exp.transform.SetPositionAndRotation(transform.position, transform.rotation);
        spawnEnemy.ReturnEnemy(transform.parent.gameObject, bonePool);
    }
}
