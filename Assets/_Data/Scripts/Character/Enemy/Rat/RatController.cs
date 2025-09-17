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

        bool dropped = Random.value < characterData.dropChange;
        if (dropped)
            DropItem.Instance.DropBulletItem(this.transform.parent);

        DropItem.Instance.DropExp1(this.transform.parent);

        spawnEnemy.ReturnEnemy(transform.parent.gameObject, ratPool);
    }
}
