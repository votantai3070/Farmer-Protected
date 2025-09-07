using UnityEngine;
using Pathfinding;

public class EnemyMovementGFX : MonoBehaviour
{
    public AIPath aIPath;
    public Enemy enemy;

    private void Start()
    {
        aIPath.maxSpeed = enemy.characterData.speed;
        aIPath.endReachedDistance = enemy.characterData.range;
        aIPath.orientation = OrientationMode.YAxisForward;
    }

    private void Update()
    {
        if (enemy == null) return;

        if (enemy.CurrentHealth <= 0)
        {
            aIPath.canMove = false;
            return;
        }
        ;

        Flip();
    }

    void Flip()
    {
        if (aIPath.desiredVelocity.x >= 0.01f)
            transform.parent.localScale = new Vector3(1f, 1f, 1f);
        else if (aIPath.desiredVelocity.x <= -0.01f)
            transform.parent.localScale = new Vector3(-1f, 1f, 1f);
    }
}
