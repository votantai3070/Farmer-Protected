using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour, IDamagable
{
    [Header("Character Setting")]
    public CharacterData characterData;
    public Slider charhealthSlider;
    float CurrentHealth { get; set; }
    float MaxHealth => characterData.maxHealth;

    private void OnEnable()
    {
        ResetHealth();
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        Debug.Log($"{gameObject.name} took {damage} damage. Current health: {CurrentHealth}/{MaxHealth}");
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

        charhealthSlider.value = CurrentHealth;

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
    }

    private void ResetHealth()
    {
        CurrentHealth = characterData.maxHealth;

        if (charhealthSlider != null)
        {
            charhealthSlider.maxValue = characterData.maxHealth;
            charhealthSlider.value = CurrentHealth;
        }

    }
}
