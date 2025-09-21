using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    Vector2 moveInput;
    public PlayerController player;
    float moveX;
    float moveY;

    public Vector2 MoveInput { get { return moveInput; } }

    private void Awake()
    {
        //if(Instance != null && Instance != this)
        //{
        //    Destroy(this);
        //    return;
        //}
        Instance = this;
    }

    void FixedUpdate()
    {
        HandleMovementInput();
    }

    private void HandleMovementInput()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;
    }

    public Vector2 HandleMovementFollowMouse()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
