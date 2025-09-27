using UnityEngine;

public class RatAttackAMS : StateMachineBehaviour
{
    [Range(0f, 1f)] public float openAt;
    [Range(0f, 1f)] public float closeAt;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!animator.TryGetComponent<RatAttackCollider>(out var attack)) return;
        attack.Close();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var attack = animator.GetComponent<RatAttackCollider>();

        float t = stateInfo.normalizedTime % 1f;

        if (attack == null) return;

        if (t >= openAt && t < closeAt) attack.Open();
        else attack.Close();
    }
}
