using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.U2D;

public class UndeadController : Enemy
{
    [Header("Undead Controller Setting")]
    private ObjectPool undeadPool;
    private SpawnEnemy spawnEnemy;

    private Sprite[] sprites;

    [SerializeField] string enemyName;
    [SerializeField] string undeadPoolName;

    protected override void Awake()
    {
        base.Awake();
        undeadPool = GameObject.Find(undeadPoolName).GetComponent<ObjectPool>();
        spawnEnemy = FindAnyObjectByType<SpawnEnemy>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        sprites = new Sprite[GameManager.Instance.characterAtlas.spriteCount];
        GameManager.Instance.characterAtlas.GetSprites(sprites);

        Sprite[] enemySprite = sprites.Where(x => x.name.StartsWith(enemyName)).ToArray();

        Sprite run0 = enemySprite.FirstOrDefault(s => s.name.Contains("Run 0"));

        spriteRenderer.sprite = run0;
    }

    protected override void Die()
    {
        base.Die();
        StartCoroutine(AnimationDead());
    }

    IEnumerator AnimationDead()
    {
        enemyAnimation.SwitchUndeadAnimation("DEAD");
        yield return new WaitForSeconds(1f);

        Transform enemyRoot = transform.parent;

        drop.SetEnemyDropItem(enemyRoot, characterData);

        drop.DropExp1(enemyRoot);

        spawnEnemy.ReturnEnemy(enemyRoot.gameObject, undeadPool);
    }

}
