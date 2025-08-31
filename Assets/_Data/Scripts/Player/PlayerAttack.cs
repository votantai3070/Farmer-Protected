using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Player player;
    public PlayerAnimation playerAnimation;
    public Rigidbody2D rb;
    public Transform firePoint;
    public ArrowPool arrowPool;

    private float attackCooldown = 0.5f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !player.isAttacked)
        {
            StartCoroutine(HandlePlayerAttack());
        }
    }

    IEnumerator HandlePlayerAttack()
    {
        player.HandleAttack();
        rb.linearVelocity = Vector2.zero;

        GetArrowFromPool();

        playerAnimation.SwitchAnimationState("BOW");

        yield return new WaitForSeconds(attackCooldown);
        playerAnimation.animator.SetBool("isAttack", false);
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

        arrow.GetComponent<ArrowMovement>().HandleArrowMovement();
    }
}
