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

        bool dropped = Random.value < characterData.dropChange;
        if (dropped)
            DropItem.Instance.DropBulletItem(this.transform.parent);

        DropItem.Instance.DropExp3(this.transform.parent);

        spawnEnemy.ReturnEnemy(transform.parent.gameObject, bonePool);
    }
}
