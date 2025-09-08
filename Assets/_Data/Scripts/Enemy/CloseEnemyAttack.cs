using System.Collections;
using UnityEngine;

public class CloseEnemyAttack : Weapon
{
    [Header("Enemy Attack Setting")]
    public EnemyAnimation enemyAnimation;
    public Enemy enemy;

    private Transform _player;
    public Rigidbody2D rb;
    public GameObject attackFX;

    bool _isAttackedFX = false;
    [SerializeField] float _activeTime = 1f;
    [SerializeField] float _delayTime = 1.5f;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;

    }

    private void Update()
    {
        HandleAttack();
    }

    private void HandleAttack()
    {
        if (enemy == null) return;

        float distance = Vector2.Distance(_player.position, rb.position);
        if (distance <= enemy.characterData.range)
            UpdateEnemyAttack();
    }

    void UpdateEnemyAttack()
    {
        if (enemy.characterData.characterName == "Rat")
        {
            if (!_isAttackedFX)
                StartCoroutine(AttackFX());
        }
        else if (enemy.characterData.characterName == "Bone")
            enemyAnimation.SwitchBoneAnimation("ATTACK");
        else if (enemy.characterData.characterName == "Slime")
            enemyAnimation.SwitchSlimeAnimation("ATTACK");
    }

    IEnumerator AttackFX()
    {
        _isAttackedFX = true;
        if (enemy.characterData.characterName == "Rat")
            enemyAnimation.SwitchRatAnimation("ATTACK");

        yield return new WaitForSeconds(_activeTime);

        if (_delayTime > 0f)
            yield return new WaitForSeconds(_delayTime);
        _isAttackedFX = false;
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
