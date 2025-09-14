using System.Collections;
using UnityEngine;
using UnityEngine.U2D;

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
        Sprite sprite = spriteAtlas.GetSprite("Stand 0");
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
        playerAnimation.SwitchAnimationState("DEAD");
        GameManager.Instance.GameOver();
    }
}
