using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [Header("Player Movement Settings")]
    public Rigidbody2D rb;
    public PlayerAnimation playerAnimation;
    public PlayerController player;
    public SpriteRenderer sprite;
    float speed;

    [Header("Dash Settings")]
    public GameObject playerGhostPrefab;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 1f;
    [SerializeField] private float ghostInterval = 0.05f;

    private bool isDashing = false;
    private float dashCooldownTimer = 0f;

    private void Start()
    {
        speed = player.characterData.speed;
    }

    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    private void Update()
    {
        if (dashCooldownTimer > 0)
            dashCooldownTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && !isDashing && dashCooldownTimer <= 0)
        {
            StartCoroutine(HandleDashing());
        }
    }



    private IEnumerator HandleDashing()
    {
        isDashing = true;
        dashCooldownTimer = dashCooldown;

        float elapsed = 0f;

        while (elapsed < dashDuration)
        {
            rb.linearVelocity = InputManager.Instance.MoveInput.normalized *
                                (player.characterData.speed + player.characterData.dashSpeed);

            Instantiate(playerGhostPrefab, transform.parent.position, transform.rotation);

            yield return new WaitForSeconds(ghostInterval);
            elapsed += ghostInterval;
        }

        isDashing = false;
    }
}
