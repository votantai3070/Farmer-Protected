using UnityEngine;

public class EnemyRangeMovement : MonoBehaviour
{
    [Header("Enemy Range Movement Setting")]
    public Enemy enemy;
    private Transform player;
    public Rigidbody2D rb;
    public BatAttack batAttack;
    public EnemyAnimation enemyAnimation;

    private float currentAngle = 0f;
    private bool isOrbiting = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        Flip(this.transform.parent);
    }

    private void FixedUpdate()
    {
        EnemyRangeMove(this.transform.parent);
    }

    void EnemyRangeMove(Transform enemyRange)
    {
        if (player == null) return;

        Vector2 direction = (player.position - enemyRange.position).normalized;

        if (enemy.CurrentHealth <= 0)
        {
            rb.linearVelocity = Vector2.zero;
            enabled = false;
            return;
        }
        else
        {
            if (Vector2.Distance(enemyRange.position, player.position) > enemy.characterData.range)
            {
                rb.linearVelocity = direction * enemy.characterData.speed;
                isOrbiting = false;
            }
            else if (enemy.characterData.characterName == "Bat")
            {
                if (!isOrbiting)
                {
                    Vector2 offset = enemyRange.position - player.position;
                    currentAngle = Mathf.Atan2(offset.y, offset.x);
                    isOrbiting = true;
                }
                MoveAroundPlayer(enemyRange);
            }
            else if (enemy.characterData.characterName == "Bone")
            {
                rb.linearVelocity = Vector2.zero;
                enemyAnimation.SwitchBoneAnimation("ATTACK");
            }
        }
    }

    void MoveAroundPlayer(Transform enemyRange)
    {
        if (rb == null) return;
        currentAngle += Time.fixedDeltaTime;
        float x = Mathf.Cos(currentAngle) * enemy.characterData.range;
        float y = Mathf.Sin(currentAngle) * enemy.characterData.range;

        Vector2 targetPos = (Vector2)player.position + new Vector2(x, y);

        float smoothSpeed = enemy.characterData.speed * 0.5f;

        enemyRange.position = Vector2.Lerp(enemyRange.position, targetPos, smoothSpeed);

        HandleEnemiesAttack();
    }

    void HandleEnemiesAttack()
    {
        if (enemy.characterData.characterName == "Bat")
            if (!batAttack.isAttacking)
                batAttack.StartCoroutine(batAttack.HandleBatThrowAttack());
    }

    void Flip(Transform enemyRange)
    {
        Vector3 localScale = enemyRange.localScale;
        if (enemyRange.position.x < player.position.x)
            localScale.x = Mathf.Abs(localScale.x);
        else
            localScale.x = -Mathf.Abs(localScale.x);
        enemyRange.localScale = localScale;
    }
}
