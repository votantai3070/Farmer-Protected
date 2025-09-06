using UnityEngine;

public class EnemyCloseMovement : MonoBehaviour
{
    [Header("Enemy Close Movement Setting")]
    public Enemy enemy;
    public Rigidbody2D rb;
    public EnemyAnimation enemyAnimation;
    private Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        Flip(this.transform.parent);
    }

    private void FixedUpdate()
    {
        HandleMovement(this.transform.parent);
    }

    private void HandleMovement(Transform enemyClose)
    {
        if (player == null || enemy == null) return;

        Vector2 direction = (player.position - enemyClose.position).normalized;

        if (enemy.CurrentHealth <= 0)
        {
            rb.linearVelocity = Vector3.zero;
            return;
        }

        if (Vector3.Distance(player.position, enemyClose.position) > enemy.characterData.range)
        {
            enemyAnimation.SwitchSlimeAnimation("RUN");
            rb.linearVelocity = direction * enemy.characterData.speed;
        }
        else
        {
            if (enemy.characterData.characterName == "Slime")
                enemyAnimation.SwitchSlimeAnimation("ATTACK");

            else if (enemy.characterData.characterName == "Rat")
                enemyAnimation.SwitchRatAnimation("ATTACK");

            rb.linearVelocity = Vector3.zero;
        }
    }

    private void Flip(Transform enemyClose)
    {
        Vector3 localScale = enemyClose.localScale;
        if (enemyClose.position.x < player.position.x)
            localScale.x = Mathf.Abs(localScale.x);
        else
            localScale.x = -Mathf.Abs(localScale.x);
        enemyClose.localScale = localScale;
    }
}
