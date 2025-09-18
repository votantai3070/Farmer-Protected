using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] GameObject inventory;
    [SerializeField] WeaponData[] weaponDatas;
    [SerializeField] InventorySlot[] slots;
    [SerializeField] private DraggableItem draggablePrefab;

    private void Start()
    {
        for (int i = 0; i < weaponDatas.Length && i < slots.Length; i++)
        {
            DraggableItem newItem = Instantiate(draggablePrefab, slots[i].transform);

            newItem.SetItem(weaponDatas[i]);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (inventory.activeSelf)
            {
                CloseInventoryBtn();
            }
            else
            {
                OpenInventoryBtn();
            }
        }

    }

    public bool AddNewWeapon(WeaponData weapon)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].transform.childCount == 0)
            {
                DraggableItem newItem = Instantiate(draggablePrefab, slots[i].transform);
                newItem.SetItem(weapon);
                return true;
            }
        }

        return false;
    }

    public void CloseInventoryBtn()
    {
        inventory.SetActive(false);
        Time.timeScale = 1f;

        Input.ResetInputAxes();
    }

    void OpenInventoryBtn()
    {
        inventory.SetActive(true);
        Time.timeScale = 0f;
    }
}
