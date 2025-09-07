using UnityEngine;

public class CloseEnemyAttack : Weapon
{
    [Header("Enemy Attack Setting")]
    public EnemyAnimation enemyAnimation;
    public Enemy enemy;

    private Transform player;
    public Rigidbody2D rb;



    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

    }

    private void Update()
    {
        if (enemy == null) return;

        InvokeRepeating("HandleAttack", 0f, .6f);
    }

    private void HandleAttack()
    {
        float distance = Vector2.Distance(player.position, rb.position);
        if (distance <= enemy.characterData.range)
            UpdateEnemyAttack();
    }

    void UpdateEnemyAttack()
    {
        if (enemy.characterData.characterName == "Rat")
            enemyAnimation.SwitchRatAnimation("ATTACK");
        else if (enemy.characterData.characterName == "Bone")
            enemyAnimation.SwitchBoneAnimation("ATTACK");
        else if (enemy.characterData.characterName == "Slime")
            enemyAnimation.SwitchSlimeAnimation("ATTACK");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.TryGetComponent<IDamagable>(out IDamagable damagable))
                Attack(damagable);
        }
    }
}
