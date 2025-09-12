using System.Collections;
using UnityEngine;

public class RangeEnemyAttack : MonoBehaviour
{
    [Header("Range Enemy Setting")]
    public GameObject stonePrefab;
    public Transform stoneSpawnPoint;
    private ObjectPool stonePool;
    private Transform player;
    public EnemyAnimation enemyAnimation;
    public Enemy enemy;
    public Rigidbody2D rb;

    [SerializeField] float delayTime = 3f;

    [HideInInspector] bool isAttacking = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (enemy.characterData.characterName == "Bat")
            stonePool = GameObject.Find("StonePool").GetComponent<ObjectPool>();
        else if (enemy.characterData.characterName == "Golem")
            stonePool = GameObject.Find("StoneBossPool").GetComponent<ObjectPool>();
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

            else if (enemy.characterData.characterName == "Golem")
                enemyAnimation.SwitchGolemAnimation("ATTACK_A");

        yield return new WaitForSeconds(delayTime);
        if (enemyAnimation != null && !isAttacking)
            if (enemy.characterData.characterName == "Bat")
                enemyAnimation.SwitchBatAnimation("FLY");

            else if (enemy.characterData.characterName == "Golem")
                enemyAnimation.SwitchBatAnimation("RUN");
        isAttacking = false;
    }

    void GetStoneFromPool()
    {
        GameObject stone = stonePool.Get();
        stone.transform.position = stoneSpawnPoint.position;

        stone.GetComponent<RangeWeaponMovement>().HandleRangeWeaponMovement(true);
    }
}
