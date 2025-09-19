using UnityEngine;

public class RangeWeaponMovement : Weapon
{
    [Header("Range Weapon Movement Setting")]
    private Rigidbody2D rb;
    private Transform player;
    private SpriteRenderer sr;

    private bool isEnemyWeapon = false;


    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        if (weaponData.weaponType == WeaponData.WeaponType.Throw)
            sr.sprite = GameManager.Instance.itemAtlas.GetSprite(weaponData.bulletSprite);

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
            rb.linearVelocity = transform.up * weaponData.speed;
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
    }
}
