using System.Collections;
using UnityEngine;

public class PlayerController : Character
{
    [Header("Player Controller Setting")]
    [HideInInspector] public bool isAttacked = false;
    public PlayerAnimation playerAnimation;

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
