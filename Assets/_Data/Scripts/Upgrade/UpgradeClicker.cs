using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeClicker : MonoBehaviour, IPointerClickHandler
{
    private GameObject upgradePanel;
    public WeaponData weaponData;
    private UpgradeManager upgradeManager;
    private InventoryManager inventoryManager;

    private void Awake()
    {
        upgradePanel = GameObject.Find("ChooseWeaponPanel");
        upgradeManager = GameObject.Find("UpgradeManager").GetComponent<UpgradeManager>();
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        upgradePanel.SetActive(false);
        GameManager.Instance.GameResume();
        UpgradeWeapon();
    }

    private void UpgradeWeapon()
    {
        if (weaponData == null) return;

        bool found = false;

        for (int i = 0; i < inventoryManager.slots.Length; i++)
        {
            if (inventoryManager.slots[i].transform.childCount > 0)
            {
                DraggableItem item = inventoryManager.slots[i].transform.GetChild(0).GetComponent<DraggableItem>();
                if (item.weaponData.weaponName == weaponData.weaponName)
                {
                    item.SetItem(weaponData);
                    upgradeManager.AddUpgrade(weaponData);
                    found = true;
                    break;
                }
            }
        }

        if (!found)
        {
            inventoryManager.AddNewWeapon(weaponData);
            upgradeManager.AddUpgrade(weaponData);
        }
    }

    public void SetWeaponData(WeaponData weapon)
    {
        weaponData = weapon;
    }
}