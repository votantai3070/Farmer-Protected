using System.Collections;
using UnityEngine;

public class RatController : Enemy
{
    [Header("Rat Controller Setting")]
    private ObjectPool ratPool;
    private SpawnEnemy spawnEnemy;
    private CapsuleCollider2D capsuleCollider;

    [Space]
    public float attackCooldown = 1f;

    public IdleState_Rat idleState { get; private set; }
    public MoveState_Rat moveState { get; private set; }
    public AttackState_Rat attackState { get; private set; }
    public DeadState_Rat deadState { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        idleState = new IdleState_Rat(this, stateMachine, "Idle");
        moveState = new MoveState_Rat(this, stateMachine, "Move");
        attackState = new AttackState_Rat(this, stateMachine, "Attack");
        deadState = new DeadState_Rat(this, stateMachine, "Dead");

        ratPool = GameObject.Find("RatPool").GetComponent<ObjectPool>();
        spawnEnemy = FindAnyObjectByType<SpawnEnemy>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsuleCollider = GetComponentInChildren<CapsuleCollider2D>();

    }

    public override void Start()
    {
        stateMachine.Initialize(idleState);

        Sprite sprite = GameManager.Instance.characterAtlas.GetSprite("Rat_Idle_0");
        spriteRenderer.sprite = sprite;
    }

    protected override void Update()
    {
        base.Update();

        stateMachine.currentState.Update();
    }

    public void DeadAnimation()
    {
        if (CurrentHealth <= 0)
        {
            stateMachine.ChangeState(deadState);
        }
    }

    public void EnableCollider2D(bool active)
    {
        capsuleCollider.enabled = active;
    }

    protected override void Die()
    {
        base.Die();
        StartCoroutine(ReturnToPoolAfterDelay(1f));
    }

    IEnumerator ReturnToPoolAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ObjectPool.instance.DelayReturnToPool(gameObject);
    }


    //IEnumerator AnimationDead()
    //{
    //    anim.SetTrigger("Dead");
    //    yield return new WaitForSeconds(1f);

    //    Transform enemyRoot = transform.parent;

    //    drop.SetEnemyDropItem(enemyRoot, characterData);

    //    drop.DropExp1(enemyRoot);

    //    ObjectPool.instance.DelayReturnToPool(enemyRoot.gameObject);
    //}
}
