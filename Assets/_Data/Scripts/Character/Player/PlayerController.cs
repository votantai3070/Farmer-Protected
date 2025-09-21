using UnityEngine;

public class PlayerController : Character
{
    [Header("Player Controller Setting")]
    [HideInInspector] public bool isAttacked = false;
    public PlayerAnimation playerAnimation;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        Sprite sprite = GameManager.Instance.characterAtlas.GetSprite("Stand 0");
        spriteRenderer.sprite = sprite;
    }

    public void HandleAttack()
    {
        isAttacked = true;
    }

    public void StopAttack()
    {
        isAttacked = false;
    }

    protected override void Die()
    {
        base.Die();
        playerAnimation.SwitchAnimationState("DEAD");
        GameManager.Instance.GameOver();
    }
}
