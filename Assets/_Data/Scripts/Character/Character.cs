using DG.Tweening;
using TMPro;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.UI;
using static CharacterData;

public class Character : MonoBehaviour, IDamagable
{
    [Header("Character Setting")]
    public CharacterData characterData;
    public Slider charhealthSlider;
    public TextMeshProUGUI playerHpText;
    protected SpriteRenderer spriteRenderer;

    public StateMachine stateMachine { get; private set; }


    private Tweener hpTween;

    public Animator anim { get; private set; }
    public float CurrentHealth { get; private set; }
    float MaxHealth => characterData.maxHealth;

    protected virtual void Awake()
    {
        stateMachine = new StateMachine();
        anim = GetComponent<Animator>();

        if (characterData != null && characterData.characterType == CharacterType.Player)
            InitializePlayer();
    }

    private void InitializePlayer()
    {
        CurrentHealth = MaxHealth;

        if (charhealthSlider != null)
        {
            charhealthSlider.maxValue = MaxHealth;
            charhealthSlider.value = CurrentHealth;
        }

        if (playerHpText != null)
            playerHpText.text = $"{CurrentHealth}/{MaxHealth}";


    }

    private void OnEnable()
    {
        if (characterData != null && characterData.characterType == CharacterType.Enemy)
            ResetGameObject();
    }

    protected virtual void Update()
    {
        //Debug.Log(gameObject.name + ": " + CurrentHealth);
        //Debug.Log(gameObject.name + ": " + MaxHealth);
    }

    public void Heal(int amount)
    {
        CurrentHealth += amount;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

        if (hpTween != null && hpTween.IsActive()) hpTween.Kill();

        if (charhealthSlider != null)
            hpTween = charhealthSlider.DOValue(CurrentHealth, 0.3f).SetEase(Ease.Linear);

        if (playerHpText != null)
            playerHpText.text = $"{CurrentHealth}/{MaxHealth}";
    }

    public void TakeDamage(int damage, bool isCrit)
    {

        CurrentHealth -= damage;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

        DamagePopupGenerator.Instance.DisplayDamage(transform.position, damage, isCrit);

        if (charhealthSlider != null)
        {
            if (hpTween != null && hpTween.IsActive()) hpTween.Kill();
            hpTween = charhealthSlider.DOValue(CurrentHealth, 0.2f).SetEase(Ease.Linear);
        }

        if (playerHpText != null)
            playerHpText.text = $"{CurrentHealth}/{MaxHealth}";

        if (CurrentHealth <= 0)
            Die();
    }

    protected virtual void Die()
    {

    }


    public void InitializeCharacterData(CharacterData data)
    {
        characterData = data;
    }

    private void ResetGameObject()
    {
        CurrentHealth = MaxHealth;

        if (charhealthSlider != null)
        {
            charhealthSlider.maxValue = MaxHealth;
            charhealthSlider.value = CurrentHealth;
        }

        //if (playerHpText != null)
        //    playerHpText.text = $"{CurrentHealth}/{MaxHealth}";

        gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }
}
