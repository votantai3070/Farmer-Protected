using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AvailableWeapon : MonoBehaviour
{
    [SerializeField] private UpgradeManager available;
    [SerializeField] GameObject chooseWeaponPrefab;
    [SerializeField] Transform parent;
    [SerializeField] GameObject chooseWeaponPanel;
    [SerializeField] GameObject boxChooseWeapon;


    public void SetAvailable()
    {
        chooseWeaponPanel.SetActive(true);

        List<WeaponData> availableList = available.AvaiableUpgrades();

        var availableSort = availableList.OrderBy(x => Random.value).Take(3).ToList();

        //Debug.Log($"Available Weapons: {string.Join(", ", availableList.Select(w => w.weaponName + " Lv" + w.level))}");

        Debug.Log($"Available Weapons Count: {availableSort.Count}");

        for (int i = 0; i < availableSort.Count; i++)
        {
            boxChooseWeapon.transform.GetChild(i).GetComponent<Image>().color = availableSort[i].rareColor;

            boxChooseWeapon.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = GameManager.Instance.UIAtlas.GetSprite(availableSort[i].UISprite);

            boxChooseWeapon.transform.GetChild(i).GetChild(1).GetComponent<TextMeshProUGUI>().text = $"{availableSort[i].weaponName} / Level {availableSort[i].level}";

            boxChooseWeapon.transform.GetChild(i).GetComponent<UpgradeClicker>().SetWeaponData(availableList[i]);
        }
    }
}
