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
        //else
        //{
        //    Idle();
        //}


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
    }

    //void Idle()
    //{
    //    if (enemy.characterData.characterName == "Rat")
    //        enemyAnimation.SwitchRatAnimation("IDLE");

    //    else if (enemy.characterData.characterName == "Bone")
    //        enemyAnimation.SwitchBoneAnimation("IDLE");

    //    else if (enemy.characterData.characterName == "Slime")
    //        enemyAnimation.SwitchSlimeAnimation("IDLE");

    //    else if (enemy.characterData.characterName == "Golem")
    //        enemyAnimation.SwitchGolemAnimation("IDLE");
    //}

    void Flip()
    {
        if (aIPath.desiredVelocity.x >= 0.01f)
            transform.parent.localScale = new Vector3(1f, 1f, 1f);
        else if (aIPath.desiredVelocity.x <= -0.01f)
            transform.parent.localScale = new Vector3(-1f, 1f, 1f);
    }
}
