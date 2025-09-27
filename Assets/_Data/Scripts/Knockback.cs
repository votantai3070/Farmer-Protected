using Pathfinding;
using System.Collections;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public static Knockback Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    public void KnockbackEffect(Rigidbody2D rb, Vector2 hitSource, float force, float duration, AIPath path)
    {
        if (rb != null)
        {
            if (path != null)
            {
                path.canMove = false;
            }
            Debug.Log("Chay vo day");
            Debug.Log("Rb: " + rb);

            Vector2 direction = (rb.position - hitSource).normalized;

            rb.linearVelocity = Vector2.zero;

            rb.AddForce(direction * force, ForceMode2D.Impulse);

            StartCoroutine(ResetVelocity(rb, duration, path));
        }
    }

    IEnumerator ResetVelocity(Rigidbody2D rb, float duration, AIPath path)
    {
        yield return new WaitForSeconds(duration);
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }
        path.canMove = true;
    }
}
