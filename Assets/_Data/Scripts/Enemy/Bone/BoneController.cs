using System.Collections;
using UnityEngine;

public class BoneController : Enemy
{
    [Header("Bone Controller Setting")]
    public EnemyAnimation boneAnimation;
    private ObjectPool bonePool;
    private SpawnEnemy spawnEnemy;

    private void Awake()
    {
        bonePool = GameObject.Find("BonePool").GetComponent<ObjectPool>();
        spawnEnemy = FindAnyObjectByType<SpawnEnemy>();
    }
    protected override void Die()
    {
        StartCoroutine(AnimationDead());
    }

    IEnumerator AnimationDead()
    {
        boneAnimation.SwitchBoneAnimation("DEAD");
        yield return new WaitForSeconds(1f);
        spawnEnemy.ReturnEnemy(transform.parent.gameObject, bonePool);
    }
}
