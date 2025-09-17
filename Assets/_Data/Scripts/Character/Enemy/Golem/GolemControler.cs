using System.Collections;
using UnityEngine;

public class GolemControler : Enemy
{
    [Header("Golem Controller Setting")]
    private ObjectPool golemPool;
    private SpawnEnemy spawnEnemy;

    private void Awake()
    {
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

        bool dropped = Random.value < characterData.dropChange;
        if (dropped)
            DropItem.Instance.DropBulletItem(this.transform.parent);

        DropItem.Instance.DropExp3(this.transform.parent);
        spawnEnemy.ReturnEnemy(transform.parent.gameObject, golemPool);
    }
}
