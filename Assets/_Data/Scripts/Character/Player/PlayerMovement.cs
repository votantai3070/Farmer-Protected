using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement Settings")]
    public Rigidbody2D rb;
    public PlayerAnimation playerAnimation;
    public PlayerController player;
    public InputManager inputManager;
    public SpriteRenderer sprite;

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
        playerAnimation.SwitchAnimationState("RUN");
        rb.linearVelocity = inputManager.MoveInput * player.characterData.speed;

        Flip();
    }

    void Flip()
    {
        if (inputManager.MoveInput.x > 0)
            sprite.flipX = false;
        else if (inputManager.MoveInput.x < 0)
            sprite.flipX = true;
    }
}
