using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [Header("Enemy Pool Setting")]
    public GameObject enemyPrefab;
    List<GameObject> enemyPool = new();

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            if (enemyPrefab != null) return;
            GameObject bat = Instantiate(enemyPrefab);
            enemyPool.Add(bat);
            bat.SetActive(false);
        }
    }

    public GameObject Get()
    {
        foreach (GameObject enemy in enemyPool)
        {
            if (!enemy.activeInHierarchy)
            {
                enemy.SetActive(true);
                return enemy;
            }
        }

        GameObject newEnemy = Instantiate(enemyPrefab);
        newEnemy.SetActive(true);
        return newEnemy;
    }

    public void ReturnPool(GameObject bat)
    {
        bat.SetActive(false);
    }
}
