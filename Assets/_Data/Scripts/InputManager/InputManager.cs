using UnityEditor.ShaderGraph;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public PlayerController player;
    private PlayerControls controls;

    Vector2 moveInput;

    public Vector2 MoveInput => moveInput;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        AssignInputEvents();
    }

    public Vector2 HandleMovementFollowMouse()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void AssignInputEvents()
    {
        controls = player.controls;

        controls.Player.Movement.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Movement.canceled += ctx => moveInput = Vector2.zero;
    }
}
