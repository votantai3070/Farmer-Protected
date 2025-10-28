using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{
    public GameObject[] prefabs;


    public GameObject CurrentBulletPrefab(Weapon weapon)
    {
        foreach (GameObject prefab in prefabs)
        {
            BulletMovement bullet = prefab.GetComponent<BulletMovement>();

            if (bullet.weaponData.weaponName == weapon.weaponData.weaponName)
            {
                return bullet.gameObject;
            }
        }

        return null;
    }
}
