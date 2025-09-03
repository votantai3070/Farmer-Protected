using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Player Attack Setting")]
    public Player player;
    public PlayerStamina playerStamina;
    public PlayerAnimation playerAnimation;
    public Rigidbody2D rb;
    public Transform firePoint;
    public ArrowPool arrowPool;
    public StonePool stonePool;

    private float attackCooldown = 0.5f;


    [Header("Stamina Setting")]
    public float bowStamina = 10;
    public float stoneStamina = 1;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !player.isAttacked)
        {
            StartCoroutine(HandlePlayerSlashAttack());
        }
        else if (Input.GetKeyDown(KeyCode.Q) &&
            !player.isAttacked &&
            playerStamina.CurrentStamina > bowStamina)
        {
            StartCoroutine(HandlePlayerBowAttack());
        }
        else if (Input.GetKeyDown(KeyCode.E) &&
            !player.isAttacked &&
            playerStamina.CurrentStamina > stoneStamina)
        {
            StartCoroutine(HandlePlayerThrowAttack());
        }
    }

    IEnumerator HandlePlayerSlashAttack()
    {
        player.HandleAttack();
        rb.linearVelocity = Vector2.zero;

        playerAnimation.SwitchAnimationState("SLASH");
        playerAnimation.animator.SetBool("Walk", false);

        yield return new WaitForSeconds(attackCooldown);
        player.StopAttack();
    }

    IEnumerator HandlePlayerThrowAttack()
    {
        player.HandleAttack();
        rb.linearVelocity = Vector2.zero;

        GetRockFromPool();

        playerAnimation.SwitchAnimationState("THROW");
        playerAnimation.animator.SetBool("Walk", false);

        yield return new WaitForSeconds(attackCooldown);
        player.StopAttack();
    }

    IEnumerator HandlePlayerBowAttack()
    {
        player.HandleAttack();
        rb.linearVelocity = Vector2.zero;

        GetArrowFromPool();
        playerStamina.UseStamina(10);
        playerAnimation.SwitchAnimationState("BOW");
        playerAnimation.animator.SetBool("Walk", false);

        yield return new WaitForSeconds(attackCooldown);
        player.StopAttack();
    }

    private void GetArrowFromPool()
    {
        if (arrowPool == null)
        {
            Debug.LogError("ArrowPool reference is missing!"); return;
        }
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 lookDir = (mousePos - transform.position).normalized;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        GameObject arrow = arrowPool.GetArrow();
        arrow.transform.position = firePoint.position;
        arrow.transform.rotation = Quaternion.Euler(0, 0, angle);

        arrow.GetComponent<RangeWeaponMovement>().HandleRangeWeaponMovement(false);
    }

    private void GetRockFromPool()
    {
        if (stonePool == null)
        {
            Debug.LogError("StonePool reference is missing!"); return;
        }
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 lookDir = (mousePos - transform.position).normalized;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        GameObject stone = stonePool.GetStone();
        stone.transform.position = firePoint.position;
        stone.transform.rotation = Quaternion.Euler(0, 0, angle);

        stone.GetComponent<RangeWeaponMovement>().HandleRangeWeaponMovement(false);
    }
}
