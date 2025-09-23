using UnityEngine;

public class RangeWeaponMovement : Weapon
{
    [Header("Range Weapon Movement Setting")]
    private Rigidbody2D rb;
    private Transform player;
    private SpriteRenderer sr;
    private HotBarManager hotBarManager;

    [SerializeField] float radius = 5f;
    [SerializeField] LayerMask enemyLayer;


    private bool isEnemyWeapon = false;


    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        hotBarManager = GameObject.Find("HotBarManager").GetComponent<HotBarManager>();
    }
    private void Start()
    {
        if (weaponData != null)
            sr.sprite = GameManager.Instance.itemAtlas.GetSprite(weaponData.bulletSprite);
    }

    private void Update()
    {
        if (hotBarManager.currentWeaponData != null)
            AutoFindEnemy();
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

    void AutoFindEnemy()
    {
        if (hotBarManager.currentWeaponData == null) return;

        if (hotBarManager.currentWeaponData.level == 3
            && hotBarManager.currentWeaponData.weaponType == WeaponData.WeaponType.Throw)
        {

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, 5f, enemyLayer);

            if (hitEnemies.Length > 0)
            {
                Transform nearestEnemy = null;
                float minDistance = Mathf.Infinity;
                foreach (var enemy in hitEnemies)
                {
                    float distance = Vector2.Distance(transform.position, enemy.transform.position);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        nearestEnemy = enemy.transform;
                    }
                }
                if (nearestEnemy != null)
                {
                    Vector2 direction = (nearestEnemy.position - transform.position).normalized;
                    rb.linearVelocity = direction * weaponData.speed;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    rb.rotation = angle - 90f;
                }

            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
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
