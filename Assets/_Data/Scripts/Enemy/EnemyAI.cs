using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    //public float nextWaypointDistance = 3f;
    Seeker seeker;

    public Rigidbody2D rb;

    public Transform enemyGFX;

    public Enemy enemy;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    public bool isAttackRanged = false;
    public float orbitRadius = 3f;
    public float orbitSpeed = 2f;
    private float orbitAngle = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        seeker = GetComponent<Seeker>();

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathCompleted);
    }

    void OnPathCompleted(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null) return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }


        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;

        orbitAngle = Random.Range(0f, 360f);

        if (!isAttackRanged)
            rb.linearVelocity = direction * enemy.characterData.speed;
        else
        {
            orbitAngle += orbitSpeed + Time.fixedDeltaTime;

            Vector2 orbitOffset = new Vector2(Mathf.Cos(orbitAngle), Mathf.Sin(orbitAngle)) * orbitRadius;
            Vector2 orbitPos = (Vector2)target.position + orbitOffset;

            Vector2 orbitDirection = (orbitPos - rb.position).normalized;

            rb.linearVelocity = orbitDirection * enemy.characterData.speed;
        }

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < enemy.characterData.range)
        {
            currentWaypoint++;
        }


        Flip();
    }

    void Flip()
    {
        if (rb.linearVelocity.x >= 0.01f)
            enemyGFX.localScale = new Vector3(1f, 1f, 1f);
        else if (rb.linearVelocity.x <= -0.01f)
            enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
    }
}
