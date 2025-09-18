using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement Settings")]
    public Rigidbody2D rb;
    public PlayerAnimation playerAnimation;
    public PlayerController player;
    public InputManager inputManager;
    public SpriteRenderer sprite;

    [Header("Dash Settings")]
    public GameObject playerGhostPrefab;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 1f;
    [SerializeField] private float ghostInterval = 0.05f;

    private bool isDashing = false;
    private float dashCooldownTimer = 0f;

    private void Update()
    {
        if (dashCooldownTimer > 0)
            dashCooldownTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && !isDashing && dashCooldownTimer <= 0)
        {
            StartCoroutine(HandleDashing());
        }
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        rb.linearVelocity = inputManager.MoveInput * player.characterData.speed;

        playerAnimation.SwitchAnimationState("RUN");

        Flip();
    }

    private IEnumerator HandleDashing()
    {
        isDashing = true;
        dashCooldownTimer = dashCooldown;

        float elapsed = 0f;

        while (elapsed < dashDuration)
        {
            rb.linearVelocity = inputManager.MoveInput.normalized *
                                (player.characterData.speed + player.characterData.dashSpeed);

            Instantiate(playerGhostPrefab, transform.parent.position, transform.rotation);

            yield return new WaitForSeconds(ghostInterval);
            elapsed += ghostInterval;
        }

        isDashing = false;
    }

    private void Flip()
    {
        if (inputManager.MoveInput.x > 0)
            sprite.flipX = false;
        else if (inputManager.MoveInput.x < 0)
            sprite.flipX = true;
    }
}
