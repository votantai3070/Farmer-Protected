using UnityEngine;
using Pathfinding;

public class EnemyMovementGFX : MonoBehaviour
{
    public AIPath aIPath;
    public Enemy enemy;
    public EnemyAnimation enemyAnimation;

    private void Start()
    {
        aIPath.maxSpeed = enemy.characterData.speed;
        aIPath.endReachedDistance = enemy.characterData.range;
        aIPath.orientation = OrientationMode.YAxisForward;
        aIPath.repathRate = Random.Range(1f, 2f);
    }

    private void Update()
    {
        if (enemy == null) return;

        if (enemy.CurrentHealth <= 0)
        {
            aIPath.canMove = false;
            return;
        }

        if (aIPath.canMove)
        {
            Move();
        }

        Flip();
    }

    void Move()
    {
        if (enemy.characterData.characterName == "Rat")
            enemyAnimation.SwitchRatAnimation("RUN");

        else if (enemy.characterData.characterName == "Bone")
            enemyAnimation.SwitchBoneAnimation("RUN");

        else if (enemy.characterData.characterName == "Slime")
            enemyAnimation.SwitchSlimeAnimation("RUN");

        else if (enemy.characterData.characterName == "Golem")
            enemyAnimation.SwitchGolemAnimation("RUN");

        //else if (enemy.characterData.characterName == "Undead")
        //    enemyAnimation.SwitchUndeadAnimation("RUN");
    }

    void Flip()
    {
        if (aIPath.desiredVelocity.x >= 0.01f)
            transform.parent.localScale = new Vector3(1f, 1f, 1f);
        else if (aIPath.desiredVelocity.x <= -0.01f)
            transform.parent.localScale = new Vector3(-1f, 1f, 1f);
    }
}
