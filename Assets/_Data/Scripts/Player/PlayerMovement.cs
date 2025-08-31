using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Settings")]
    public Rigidbody2D rb;
    public PlayerAnimation playerAnimation;
    public Player player;
    public InputManager inputManager;

    void FixedUpdate()
    {
        if (!player.isAttacked)
        {
            HandleMovement();
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    private void HandleMovement()
    {
        playerAnimation.SwitchAnimationState("WALK");
        rb.linearVelocity = inputManager.MoveInput * player.characterData.speed;
    }
}
