using System.Collections;
using UnityEngine;

public class BatController : Enemy
{
    [Header("Bat Controller Setting")]
    private ObjectPool batPool;
    private SpawnEnemy spawnEnemy;

    private void Awake()
    {
        batPool = GameObject.Find("BatPool").GetComponent<ObjectPool>();
        spawnEnemy = FindAnyObjectByType<SpawnEnemy>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
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
        bool dropped = Random.value < characterData.dropChange;
        if (dropped)
            DropItem.Instance.DropBulletItem(this.transform.parent);
        DropItem.Instance.DropExp2(this.transform.parent);
        spawnEnemy.ReturnEnemy(transform.parent.gameObject, batPool);
    }
}
