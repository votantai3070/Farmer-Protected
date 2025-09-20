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

    public void SetAvailable()
    {
        chooseWeaponPanel.SetActive(true);

        List<WeaponData> availableList = available.AvaiableUpgrades();

        availableList.OrderBy(x => Random.value).Take(3).ToList();

        //Debug.Log($"Available Weapons: {string.Join(", ", availableList.Select(w => w.weaponName + " Lv" + w.level))}");

        Debug.Log($"Available Weapons Count: {availableList.Count}");

        for (int i = 0; i < availableList.Count; i++)
        {
            GameObject choose = Instantiate(chooseWeaponPrefab, parent.position, Quaternion.identity);

            choose.transform.SetParent(parent, false);

            choose.GetComponent<Image>().color = availableList[i].rareColor;

            choose.transform.GetChild(0).GetComponent<Image>().sprite = GameManager.Instance.UIAtlas.GetSprite(availableList[i].UISprite);

            choose.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = $"{availableList[i].weaponName} / Level {availableList[i].level}";

            choose.GetComponent<Upgrade>().SetWeaponData(availableList[i]);
        }
    }
}
