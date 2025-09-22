using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeClicker : MonoBehaviour, IPointerClickHandler
{
    private GameObject upgradePanel;
    public WeaponData weaponData;
    private HotBarManager hotBarManager;
    private UpgradeManager upgradeManager;

    private void Awake()
    {
        upgradePanel = GameObject.Find("ChooseWeaponPanel");
        hotBarManager = GameObject.Find("HotBarManager").GetComponent<HotBarManager>();
        upgradeManager = GameObject.Find("UpgradeManager").GetComponent<UpgradeManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        upgradePanel.SetActive(false);
        GameManager.Instance.GameResume();
        UpgradeWeapon();
    }

    private void UpgradeWeapon()
    {
        if (weaponData != null)
        {
            for (int i = 0; i < hotBarManager.hotbarSlots.Length; i++)
            {
                if (hotBarManager.hotbarSlots[i].transform.childCount > 0)
                {
                    if (hotBarManager.hotbarSlots[i].transform.GetChild(0).GetComponent<DraggableItem>().weaponData.weaponName == weaponData.weaponName)
                    {
                        DraggableItem newItem = hotBarManager.hotbarSlots[i].transform.GetChild(0).GetComponent<DraggableItem>();
                        Debug.Log("Weapon Clicker: " + weaponData);
                        newItem.SetItem(weaponData);
                        upgradeManager.AddUpgrade(weaponData);
                        return;
                    }
                }
            }
        }
    }

    public void SetWeaponData(WeaponData weapon)
    {
        weaponData = weapon;
    }
}