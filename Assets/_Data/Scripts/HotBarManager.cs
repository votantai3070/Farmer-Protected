using UnityEngine;

public class HotBarManager : MonoBehaviour
{
    [Header("Hot Bar Manager")]
    [SerializeField] private InventorySlot[] hotbatSlots;

    [HideInInspector] public WeaponData currentWeaponData;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) UseWeaponInSlot(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) UseWeaponInSlot(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) UseWeaponInSlot(2);
    }

    public void UseWeaponInSlot(int index)
    {
        if (index >= 0 || index < hotbatSlots.Length)
        {
            WeaponData weapon = hotbatSlots[index].GetWeaponData();

            if (weapon != null)
            {
                Debug.Log("Current weapon: " + weapon.weaponName);
                currentWeaponData = weapon;
            }
            else
            {
                Debug.Log("Slot " + index + " is empty!");
            }
        }
    }
}
