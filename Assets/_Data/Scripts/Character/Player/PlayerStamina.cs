using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStamina : MonoBehaviour
{
    [Header("Player Stamina Setting")]
    public PlayerController player;
    public Slider staminaSlider;

    public float CurrentStamina { get; private set; }
    float MaxStamina { get; set; }

    float staminaDelayTimer = 0;
    float staminaDelay = 3f;

    private void Start()
    {
        MaxStamina = player.characterData.stamina;
        CurrentStamina = MaxStamina;

        if (staminaSlider != null)
        {
            staminaSlider.value = CurrentStamina;
            staminaSlider.maxValue = MaxStamina;
        }
    }

    private void Update()
    {
        RegenStamina(5);
    }
    public void UseStamina(float amount)
    {
        if (HasEnoughStamina(amount))
        {
            staminaDelayTimer = staminaDelay;
            CurrentStamina = Mathf.Clamp(CurrentStamina - amount, 0, MaxStamina);
            if (staminaSlider != null)
                staminaSlider
                    .DOValue(CurrentStamina, 0.3f) // tween trong 0.3s
                    .SetEase(Ease.OutQuad);
        }
    }

    void RegenStamina(float amount)
    {
        if (staminaDelayTimer > 0)
        {
            staminaDelayTimer -= Time.deltaTime;
            return;
        }

        CurrentStamina += amount * Time.deltaTime; // Regen amount/s
        CurrentStamina = Mathf.Clamp(CurrentStamina, 0, MaxStamina);

        if (staminaSlider != null)
            staminaSlider
                    .DOValue(CurrentStamina, 0.2f)
                    .SetEase(Ease.Linear);


    }

    bool HasEnoughStamina(float amount)
    {
        return CurrentStamina >= amount;
    }
}
