using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Pool Setting")]
    [SerializeField] private ObjectPool exp1Pool;
    [SerializeField] private ObjectPool exp2Pool;
    [SerializeField] private ObjectPool exp3Pool;
    [SerializeField] private ObjectPool bulletItemPool;
    [SerializeField] private ObjectPool potionPool;
    [SerializeField] private ObjectPool speedPool;

    [Header("Exp Slider Setting")]
    [SerializeField] private List<float> expTable;
    [SerializeField] private ItemData exp;
    [SerializeField] private Slider expSlider;
    [SerializeField] private TextMeshProUGUI expText;
    [SerializeField] private TextMeshProUGUI levelText;
    private float _currentExp;
    private int _currentLevel;
    private float _expToNextLevel;

    [Header("Bullet")]
    [SerializeField] private Bullet bullet;

    [Header("Potion")]
    [SerializeField] private PlayerController player;

    [Header("Chest")]
    private ChestController nearbyChest;

    [Header("Select Weapon")]
    [SerializeField] private AvailableUpgrade availableWeapon;

    [Header("Speed Item")]
    [SerializeField] private PlayerMovement playerMovement;

    private void Start()
    {
        _currentLevel = 1;
        _currentExp = exp.value;
        _expToNextLevel = expTable[0];
        expSlider.value = _currentExp;
        expSlider.maxValue = _expToNextLevel;
        expText.text = $"{_currentExp}/{_expToNextLevel}";
        levelText.text = $"Level {_currentLevel}";
    }

    private void Update()
    {
        if (_currentExp >= _expToNextLevel && _currentLevel < expTable.Count)
        {
            _currentExp -= _expToNextLevel;
            expSlider.DOValue(_currentExp, 0.2f).SetEase(Ease.Linear);

            LevelUp();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            UseChest();
        }

    }

    void AddExp(float amountExp)
    {
        _currentExp += amountExp;
        _currentExp = Mathf.Clamp(_currentExp, 0, _expToNextLevel);
        expText.text = $"{_currentExp}/{_expToNextLevel}";
        expSlider.DOValue(_currentExp, 0.2f).SetEase(Ease.Linear);
    }

    void LevelUp()
    {
        _currentLevel++;
        _expToNextLevel = GetExpToNextLevel();
        expSlider.maxValue = _expToNextLevel;
        expText.text = $"{_currentExp}/{_expToNextLevel}";
        levelText.text = $"Level {_currentLevel}";
        ShowSelectWeaponPanel();
    }

    private float GetExpToNextLevel()
    {
        if (_currentLevel < expTable.Count)
            return expTable[_currentLevel - 1];
        else
            return expTable[expTable.Count - 1];
    }
    private void ShowSelectWeaponPanel()
    {
        availableWeapon.SetWeaponAvailable();
        GameManager.Instance.GamePause();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;

        if (collision.CompareTag("Exp1"))
        {
            if (collision.TryGetComponent<ExpController>(out var exp))
            {
                AddExp(exp.itemData.value);
            }
            exp1Pool.ReturnPool(collision.gameObject);
        }

        else if (collision.CompareTag("Exp2"))
        {
            if (collision.TryGetComponent<ExpController>(out var exp))
            {
                AddExp(exp.itemData.value);
            }
            exp2Pool.ReturnPool(collision.gameObject);
        }

        else if (collision.CompareTag("Exp3"))
        {
            if (collision.TryGetComponent<ExpController>(out var exp))
            {
                AddExp(exp.itemData.value);
            }
            exp3Pool.ReturnPool(collision.gameObject);
        }

        else if (collision.CompareTag("BulletItem"))
        {
            if (collision.TryGetComponent<BulletItemController>(out var bulletItem))
            {
                bullet.AddAmmo(bulletItem.itemData);
            }
            bulletItemPool.ReturnPool(collision.gameObject);
        }

        else if (collision.CompareTag("Potion"))
        {
            if (collision.TryGetComponent<PotionController>(out var potion))
            {
                player.Heal(potion.itemData.value);
            }
            potionPool.ReturnPool(collision.gameObject);
        }

        else if (collision.CompareTag("Chest"))
        {
            if (collision.TryGetComponent<ChestController>(out var chest))
            {
                if (nearbyChest == null)
                    nearbyChest = chest;
            }
        }

        else if (collision.CompareTag("Speed"))
        {
            if (collision.TryGetComponent<SpeedItemController>(out var speed))
            {

                StartCoroutine(playerMovement.BoostSpeed(speed.itemData.value, speed.itemData.timeLimit));
            }
            speedPool.ReturnPool(collision.gameObject);
        }

        else if (collision.CompareTag("Magnet"))
        {
            if (collision.TryGetComponent<MagnetController>(out var mag))
            {

                StartCoroutine(mag.MagnetEffect());
            }
            speedPool.ReturnPool(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Chest"))
        {
            if (nearbyChest != null && collision.GetComponent<ChestController>() == nearbyChest)
                nearbyChest = null;
        }
    }

    void UseChest()
    {
        if (nearbyChest != null && !nearbyChest.isOpened)
        {
            nearbyChest.OpenChest();
            nearbyChest = null;
        }
    }
}
