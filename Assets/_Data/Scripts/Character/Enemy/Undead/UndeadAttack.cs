using UnityEngine;

public class UndeadAttack : Weapon
{
    [SerializeField] private EnemyAnimation enemyAnimation;
    private BoxCollider2D boxCollider2D;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        boxCollider2D.enabled = true;
    }

    private void Update()
    {
        if (enemyAnimation.animator.GetCurrentAnimatorStateInfo(0).IsName("Dead"))
        {
            boxCollider2D.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.TryGetComponent<IDamagable>(out var damagable))
            {
                Attack(damagable);
            }
        }
    }
}
