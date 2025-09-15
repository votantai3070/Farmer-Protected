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
        expPool = GameObject.Find("Exp1Pool").GetComponent<ObjectPool>();
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
        StartCoroutine(AnimationDead());
    }

    IEnumerator AnimationDead()
    {
        slimeAnimation.SwitchSlimeAnimation("DEAD");
        yield return new WaitForSeconds(1f);
        GameObject exp = expPool.Get();
        exp.transform.SetPositionAndRotation(transform.position, transform.rotation);
        spawnEnemy.ReturnEnemy(transform.parent.gameObject, slimePool);
    }
}
