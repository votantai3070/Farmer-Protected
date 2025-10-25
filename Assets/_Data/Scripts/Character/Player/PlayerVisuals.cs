using Unity.VisualScripting;
using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{
    public GameObject[] prefabs;


    public GameObject CurrentPrefab(WeaponData weaponData)
    {
        foreach (GameObject prefab in prefabs)
        {
            RangeWeaponMovement weapon = prefab.GetComponent<RangeWeaponMovement>();

            if (weapon.weaponData.weaponName == weaponData.weaponName)
            {
                return weapon.gameObject;
            }
        }

        return null;
    }
}
