using UnityEngine;

public class BoneAttackAMS : StateMachineBehaviour
{
    [Range(0f, 1f)] public float openAt = 0.2f;

    [Range(0f, 1f)] public float closeAt = 0.5f;


    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var attack = animator.GetComponent<BoneAttackCollider>();

        attack.Close();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var attack = animator.GetComponent<BoneAttackCollider>();

        float t = stateInfo.normalizedTime % 1f;

        if (t >= openAt && t < closeAt) attack.Open();
        else attack.Close();
    }
}
