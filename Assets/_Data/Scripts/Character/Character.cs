using Pathfinding;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using static CharacterData;

public class Character : MonoBehaviour, IDamagable
{
    [Header("Character Setting")]
    public AIPath path;
    public CharacterData characterData;
    public EnemyAnimation enemyAnimation;
    public Slider charhealthSlider;
    public TextMeshProUGUI playerHpText;
    [HideInInspector] public ObjectPool expPool;
    protected SpriteRenderer spriteRenderer;


    public float CurrentHealth { get; private set; }
    float MaxHealth => characterData.maxHealth;

    private void OnEnable()
    {
        ResetGameObject();
    }

    void Update()
    {
        if (enemyAnimation != null)
        {
            bool isHit = enemyAnimation.animator.GetCurrentAnimatorStateInfo(0).IsName("Hit");
            path.canMove = !isHit;
        }
    }


    public void TakeDamage(int damage, bool isCrit)
    {
        if (enemyAnimation != null)
            enemyAnimation.GetAnimationHitForEnemy();

        CurrentHealth -= damage;
        Debug.Log($"{gameObject.name} took {damage} damage. Current health: {CurrentHealth}/{MaxHealth}");
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

        DamagePopupGenerator.Instance.DisplayDamage(transform.position, damage, isCrit);

        if (charhealthSlider != null)
            charhealthSlider.value = CurrentHealth;

        if (playerHpText != null)
            playerHpText.text = $"{CurrentHealth}/{MaxHealth}";

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
    }


    private void ResetGameObject()
    {
        if (characterData.characterType == CharacterType.Enemy)
            path.canMove = true;

        CurrentHealth = MaxHealth;

        if (charhealthSlider != null)
        {
            charhealthSlider.maxValue = MaxHealth;
            charhealthSlider.value = CurrentHealth;
        }

        if (playerHpText != null)
            playerHpText.text = $"{CurrentHealth}/{MaxHealth}";
    }
}
