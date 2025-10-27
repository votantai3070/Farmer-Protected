using UnityEngine;

[SerializeField]
public struct BatControllerSettings
{
    public float bulletSpeed;
}

public class Enemy_Range : Enemy
{
    [Header("Enemy Range Controller Setting")]
    public BatControllerSettings settings;
    public float attackCooldown = 1f;
    [SerializeField] private GameObject stonePrefab;
    [SerializeField] private string spriteName;

    public IdleState_Range idleState { get; private set; }
    public MoveState_Range moveState { get; private set; }
    public AttackState_Range attackState { get; private set; }


    protected override void Awake()
    {
        base.Awake();

        idleState = new IdleState_Range(this, stateMachine, "Idle");
        moveState = new MoveState_Range(this, stateMachine, "Move");
        attackState = new AttackState_Range(this, stateMachine, "Attack");

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Start()
    {
        base.Start();
        Sprite sprite = GameManager.Instance.characterAtlas.GetSprite(spriteName);
        spriteRenderer.sprite = sprite;

        Debug.Log("Bat Settings Bullet Speed: " + settings.bulletSpeed);

        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();


        if (stateMachine.currentState != null)
            stateMachine.currentState.Update();
    }

    public void HandleAttack()
    {
        GameObject stone = ObjectPool.instance.GetObject(stonePrefab);
        stone.transform.position = transform.position;
        stone.transform.rotation = Quaternion.identity;

        stone.GetComponent<RangeWeaponMovement>().HandleRangeWeaponMovement(true);
    }

    protected override void Die()
    {
        base.Die();

    }
}
