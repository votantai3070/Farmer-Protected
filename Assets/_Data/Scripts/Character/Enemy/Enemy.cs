using Pathfinding;
using UnityEngine;

[System.Serializable]
public struct AIPathSettings
{
    public float maxSpeed;
    public float endReachedDistance;
    public float repathRate;
}

public class Enemy : Character
{
    [Header("Enemy Setting")]
    protected DropItem drop;

    public float idleTime = 2f;

    public AIPathSettings aIPathSettings;

    public StateMachine stateMachine { get; private set; }
    public AIPath aIPath { get; private set; }
    public Animator anim { get; private set; }

    protected virtual void Awake()
    {
        stateMachine = new StateMachine();
        aIPath = GetComponentInParent<AIPath>();
        anim = GetComponent<Animator>();

        InitializeAIPath();
        drop = GameObject.Find("GameManager").GetComponent<DropItem>();
    }

    protected override void Update()
    {
        Flip();
    }

    public virtual void Start()
    {

    }

    public void CanMove(bool activeMove)
    {
        aIPath.canMove = activeMove;
    }

    public float GetAnimationClipDuration(string animName)
    {
        AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;

        foreach (var clip in clips)
        {
            if (clip.name == animName)
            {
                return clip.length;
            }
        }
        return 0f;
    }

    public void InitializeAIPath()
    {
        aIPath.maxSpeed = aIPathSettings.maxSpeed;
        aIPath.endReachedDistance = aIPathSettings.endReachedDistance;
        aIPath.repathRate = aIPathSettings.repathRate;
        aIPath.orientation = OrientationMode.YAxisForward;
    }

    private void Flip()
    {
        if (aIPath.desiredVelocity.x >= 0.01f)
            transform.parent.localScale = new Vector3(1f, 1f, 1f);
        else if (aIPath.desiredVelocity.x <= -0.01f)
            transform.parent.localScale = new Vector3(-1f, 1f, 1f);
    }
}
