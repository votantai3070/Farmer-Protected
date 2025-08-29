using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    public PlayerAnimation playerAnimation;
    public Player player;

    public float moveSpeed = 5f;

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        int moveX = 0;
        int moveY = 0;

        if (Input.GetKey(KeyCode.W)) moveY = 1;
        else if (Input.GetKey(KeyCode.S)) moveY = -1;

        if (Input.GetKey(KeyCode.A)) moveX = -1;
        else if (Input.GetKey(KeyCode.D)) moveX = 1;

        playerAnimation.animator.SetInteger("moveX", moveX);
        playerAnimation.animator.SetInteger("moveY", moveY);

        rb.linearVelocity = new Vector2(moveX, moveY).normalized * player.characterData.speed;
    }
}
