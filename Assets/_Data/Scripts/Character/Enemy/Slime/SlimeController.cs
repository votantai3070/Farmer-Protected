using System.Collections;
using UnityEngine;

public class SlimeController : Enemy
{
    public EnemyAnimation slimeAnimation;
    private ObjectPool slimePool;
    private SpawnEnemy spawnEnemy;

    private void Awake()
    {
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

        bool dropped = Random.value < characterData.dropChange;
        if (dropped)
            DropItem.Instance.DropBulletItem(this.transform.parent);

        DropItem.Instance.DropExp1(this.transform.parent);

        spawnEnemy.ReturnEnemy(transform.parent.gameObject, slimePool);
    }
}
