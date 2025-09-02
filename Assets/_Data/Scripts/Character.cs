using UnityEngine;

public class Character : MonoBehaviour, IDamagable
{
    public CharacterData characterData;
    float CurrentHealth { get; set; }
    float MaxHealth => characterData.maxHealth;
    private void Start()
    {
        CurrentHealth = characterData.maxHealth;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        Debug.Log($"{gameObject.name} took {damage} damage. Current health: {CurrentHealth}/{MaxHealth}");
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
    }
}
