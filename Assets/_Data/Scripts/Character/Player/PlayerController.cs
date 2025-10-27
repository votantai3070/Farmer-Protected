using System.Collections;
using UnityEngine;

public class PlayerController : Character
{
    public PlayerControls controls;

    [Header("Player Controller Setting")]
    [HideInInspector] public bool isAttacked = false;
    public PlayerAnimation playerAnimation;
    public PlayerVisuals visuals { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        controls = new PlayerControls();

        visuals = GetComponent<PlayerVisuals>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        //SaveAndLoadCharacterData();
    }

    private void SaveAndLoadCharacterData()
    {
        string data = PlayerPrefs.GetString("Character", "Player Lv1");
        characterData = Resources.Load<CharacterData>($"Upgrade/Player/{data}");

        InitializeCharacterData(characterData);
    }

    private void Start()
    {
        Sprite sprite = GameManager.Instance.characterAtlas.GetSprite("Stand 0");
        spriteRenderer.sprite = sprite;
    }



    public void HandleAttack()
    {
        isAttacked = true;
    }

    public void StopAttack()
    {
        isAttacked = false;
    }

    protected override void Die()
    {
        base.Die();
        playerAnimation.SwitchAnimationState("DEAD");
        GameManager.Instance.GameOver();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

}
