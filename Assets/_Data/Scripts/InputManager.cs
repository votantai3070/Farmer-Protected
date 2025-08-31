using UnityEngine;

public class InputManager : MonoBehaviour
{
    Vector2 moveInput;
    public Player player;
    float moveX;
    float moveY;

    public Vector2 MoveInput { get { return moveInput; } }

    void FixedUpdate()
    {
        if (!player.isAttacked)
            HandleMovementInput();
    }

    private void HandleMovementInput()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;
    }
}
