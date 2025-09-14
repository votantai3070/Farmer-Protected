using DG.Tweening;
using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExp : MonoBehaviour
{
    [Header("Exp Pool Setting")]
    [SerializeField] private ObjectPool exp1Pool;
    [SerializeField] private ObjectPool exp2Pool;
    [SerializeField] private ObjectPool exp3Pool;

    [Header("Exp Slider Setting")]
    [SerializeField] private List<float> expTable;
    [SerializeField] private ItemData exp;
    [SerializeField] private Slider expSlider;
    [SerializeField] private TextMeshProUGUI expText;
    [SerializeField] private TextMeshProUGUI levelText;
    private float _currentExp;
    private int _currentLevel;
    private float _expToNextLevel;

    private void Start()
    {
        _currentLevel = 1;
        _currentExp = exp.value;
        _expToNextLevel = expTable[0];
        expSlider.value = _currentExp;
        expSlider.maxValue = _expToNextLevel;
        expText.text = $"{_currentExp}" + "/" + $"{_expToNextLevel}";
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
    }

    void AddExp(float amountExp)
    {
        _currentExp += amountExp;
        _currentExp = Mathf.Clamp(_currentExp, 0, _expToNextLevel);
        expText.text = $"{_currentExp}" + "/" + $"{_expToNextLevel}";
        expSlider.DOValue(_currentExp, 0.2f).SetEase(Ease.Linear);
    }

    void LevelUp()
    {
        _currentLevel++;
        _expToNextLevel = GetExpToNextLevel();
        expSlider.maxValue = _expToNextLevel;
        expText.text = $"{_currentExp}" + "/" + $"{_expToNextLevel}";
        levelText.text = $"Level {_currentLevel}";
    }

    private float GetExpToNextLevel()
    {
        if (_currentLevel < expTable.Count)
            return expTable[_currentLevel - 1];
        else
            return expTable[expTable.Count - 1];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;

        if (collision.CompareTag("Exp1"))
        {
            exp1Pool.ReturnPool(collision.gameObject);
            if (collision.TryGetComponent<ExpController>(out var exp))
            {
                AddExp(exp.expData.value);
            }
        }
        else if (collision.CompareTag("Exp2"))
        {
            exp2Pool.ReturnPool(collision.gameObject);
        }
        else if (collision.CompareTag("Exp3"))
        {
            exp3Pool.ReturnPool(collision.gameObject);
        }
    }
}
