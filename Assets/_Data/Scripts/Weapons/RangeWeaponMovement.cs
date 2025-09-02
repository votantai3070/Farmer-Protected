using UnityEngine;

public class RangeWeaponMovement : Weapon
{
    private Rigidbody2D rb;
    private Transform player;

    private bool isEnemyWeapon = false;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    public void HandleRangeWeaponMovement(bool enemyWeapon)
    {
        if (enemyWeapon)
        {
            isEnemyWeapon = true;
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * weaponData.speed;
        }
        else
        {
            isEnemyWeapon = false;
            rb.linearVelocity = transform.right * weaponData.speed;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isEnemyWeapon)
        {
            if (collision.TryGetComponent<IDamagable>(out var damagable))
            {
                Attack(damagable);
            }
            gameObject.SetActive(false);
        }

        else if (collision.CompareTag("Enemy") && !isEnemyWeapon)
        {
            if (collision.TryGetComponent<IDamagable>(out var damagable))
            {
                Attack(damagable);
            }
            gameObject.SetActive(false);
        }
        //else if (collision.CompareTag("Ground") || collision.CompareTag("Obstacle"))
        //{
        //    gameObject.SetActive(false);
        //}
    }
}
