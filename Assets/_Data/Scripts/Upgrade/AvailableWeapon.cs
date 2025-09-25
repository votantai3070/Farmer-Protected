using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AvailableWeapon : MonoBehaviour
{
    [SerializeField] private UpgradeManager available;

    [Header("Available Weapon")]
    [SerializeField] GameObject chooseWeaponPrefab;
    [SerializeField] Transform parent;
    [SerializeField] GameObject chooseWeaponPanel;
    [SerializeField] GameObject chooseWeapon;


    // Setup available weapons
    public void SetAvailable()
    {
        chooseWeaponPanel.SetActive(true);

        List<WeaponData> availableList = available.AvaiableUpgrades();

        var availableSort = availableList
             .OrderBy(x => Random.value)                     // random
             .DistinctBy(w => new { w.weaponName, w.level }) // loại trùng
             .Take(Mathf.Min(3, availableList.Count))
             .ToList();

        Debug.Log($"Available Weapons: {string.Join(", ", availableList.Select(w => w.weaponName + " Lv" + w.level))}");

        Debug.Log($"Available Weapons Count: {availableSort.Count}");

        for (int i = 0; i < chooseWeapon.transform.childCount; i++)
        {
            if (availableSort.Count > i)
            {
                chooseWeapon.transform.GetChild(i).gameObject.SetActive(true);

                chooseWeapon.transform.GetChild(i).GetComponent<Image>().color = availableSort[i].rareColor;

                chooseWeapon.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = GameManager.Instance.UIAtlas.GetSprite(availableSort[i].UISprite);

                chooseWeapon.transform.GetChild(i).GetChild(1).GetComponent<TextMeshProUGUI>().text = $"{availableSort[i].weaponName} / Level {availableSort[i].level}";

                chooseWeapon.transform.GetChild(i).GetComponent<UpgradeClicker>().SetWeaponData(availableSort[i]);
            }
            else
                chooseWeapon.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    // Setup available players
    public void SetPlayerAvailable()
    {
        List<CharacterData> characterDatas = available.playerUpgrade();
    }
}
