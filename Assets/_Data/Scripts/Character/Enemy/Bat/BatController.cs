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
        expPool = GameObject.Find("Exp2Pool").GetComponent<ObjectPool>();
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
        GameObject exp = expPool.Get();
        exp.transform.SetPositionAndRotation(transform.position, transform.rotation);
        spawnEnemy.ReturnEnemy(transform.parent.gameObject, batPool);
    }
}
