using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [Header("Weapon Upgrade")]
    [SerializeField] private List<WeaponData> upgradeList = new();
    public List<WeaponData> currentUpgradeList = new();

    [Header("Player Upgrade")]
    [SerializeField] private List<CharacterData> upgradePlayerList = new();
    public List<CharacterData> currentUpgradePlayerList = new();

    // Weapon Upgrade
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

    // Add Weapon Upgrade
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

    // Player Upgrade
    public List<CharacterData> playerUpgrade()
    {
        List<CharacterData> characterDatas = new();

        foreach (var upgrade in upgradePlayerList)
        {
            // Check if the character is not already owned
            bool notOwned = !currentUpgradePlayerList.Exists(u => u.characterName == upgrade.characterName && u.level == upgrade.level);
            // Check if the previous level of the same character is owned
            bool preLevelOwned = upgrade.level == 1 ||
                currentUpgradePlayerList.Exists(u => u.characterName == upgrade.characterName && u.level == upgrade.level - 1);
            if (notOwned && preLevelOwned)
            {
                characterDatas.Add(upgrade);
            }
            else
            {
                characterDatas.Remove(upgrade);
            }
        }
        return characterDatas;
    }

    // Add Player Upgrade
    public void AddPlayerUpgrade(CharacterData newUpgrade)
    {
        if (!currentUpgradePlayerList.Exists(u => u.characterName == newUpgrade.characterName && u.level == newUpgrade.level))
        {
            currentUpgradePlayerList.Add(newUpgrade);
            upgradePlayerList.Remove(newUpgrade);
        }
        else
        {
            Debug.LogWarning($"UpgradeClicker {newUpgrade.characterName} level {newUpgrade.level} is already owned.");
        }
    }
}
