using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private List<WeaponData> upgradeList = new();
    [SerializeField] public List<WeaponData> currentUpgradeList = new();

    public List<WeaponData> AvaiableUpgrades()
    {
        List<WeaponData> availableUpgrades = new();

        foreach (var upgrade in upgradeList)
        {
            // Check if the weapon is not already owned
            bool notOwned = !currentUpgradeList.Exists(u => u.weaponName == upgrade.weaponName && u.level == upgrade.level);

            // Check if the previous level of the same weapon is owned
            bool preLevelOwned = upgrade.level == 1 ||
                currentUpgradeList.Exists(u => u.weaponName == upgrade.weaponName && u.level == upgrade.level - 1);

            if (notOwned && preLevelOwned)
            {
                availableUpgrades.Add(upgrade);
            }
            else
            {
                availableUpgrades.Remove(upgrade);
            }
        }

        return availableUpgrades;
    }

    public void AddUpgrade(WeaponData newUpgrade)
    {
        if (!currentUpgradeList.Exists(u => u.weaponName == newUpgrade.weaponName && u.level == newUpgrade.level))
        {
            currentUpgradeList.Add(newUpgrade);
            upgradeList.Remove(newUpgrade);
        }
        else
        {
            Debug.LogWarning($"UpgradeClicker {newUpgrade.weaponName} level {newUpgrade.level} is already owned.");
        }
    }
}
