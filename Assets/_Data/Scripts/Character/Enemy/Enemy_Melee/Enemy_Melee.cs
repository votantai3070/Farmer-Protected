using System.Collections;
using UnityEngine;

public class Enemy_Melee : Enemy
{
    [Header("Enemy Melee Controller Setting")]
    private CapsuleCollider2D capsuleCollider;

    [Space]
    [SerializeField] private string spriteName;
    public float attackCooldown = 1f;

    public IdleState_Melee idleState { get; private set; }
    public MoveState_Melee moveState { get; private set; }
    public AttackState_Melee attackState { get; private set; }
    public DeadState_Melee deadState { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        idleState = new IdleState_Melee(this, stateMachine, "Idle");
        moveState = new MoveState_Melee(this, stateMachine, "Move");
        attackState = new AttackState_Melee(this, stateMachine, "Attack");
        deadState = new DeadState_Melee(this, stateMachine, "Dead");

        spriteRenderer = GetComponent<SpriteRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();

    }

    protected override void Start()
    {
        stateMachine.Initialize(idleState);

        Sprite sprite = GameManager.Instance.characterAtlas.GetSprite(spriteName);
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
}
