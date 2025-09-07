using System.Collections;
using UnityEngine;

public class RangeEnemyAttack : MonoBehaviour
{
    [Header("Bat Enemy Setting")]
    public Weapon weapon;
    public GameObject stonePrefab;
    public Transform stoneSpawnPoint;
    private ObjectPool stonePool;
    private Transform player;
    public EnemyAnimation enemyAnimation;
    public Enemy enemy;

    public Rigidbody2D rb;

    [HideInInspector] public bool isAttacking = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        stonePool = GameObject.Find("StonePool").GetComponent<ObjectPool>();
    }

    //private void Start()
    //{
    //    InvokeRepeating("HandleAttack", 0f, 2f);
    //}

    private void Update()
    {
        if (!isAttacking)
            HandleAttack();
    }

    private void HandleAttack()
    {
        float distance = Vector2.Distance(player.position, rb.position);
        if (distance <= enemy.characterData.range)
            StartCoroutine(HandleBatThrowAttack());
    }

    public IEnumerator HandleBatThrowAttack()
    {
        isAttacking = true;
        GetStoneFromPool();
        if (enemyAnimation != null && isAttacking)
            if (enemy.characterData.characterName == "Bat")
                enemyAnimation.SwitchBatAnimation("ATTACK");
        yield return new WaitForSeconds(1f);
        if (enemyAnimation != null && !isAttacking)
            if (enemy.characterData.characterName == "Bat")
                enemyAnimation.SwitchBatAnimation("FLY");
        isAttacking = false;
    }

    void GetStoneFromPool()
    {
        GameObject stone = stonePool.Get();
        stone.transform.position = stoneSpawnPoint.position;

        stone.GetComponent<RangeWeaponMovement>().HandleRangeWeaponMovement(true);
    }
}
