using UnityEngine;
[CreateAssetMenu(fileName = "New TakeDamaged", menuName = "TakeDamaged/WeaponData")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public int level;
    public string description;

    public WeaponType weaponType;
    public string ingameSprite;
    public string bulletSprite;
    public string UISprite;
    public int firstDamage;
    public int lastDamage;
    public float range;
    public float bulletSpeed;
    public float criticalChange;
    public float criticalDamage;
    public float stamina;
    public int magazineSize;
    public int bulletShotSize;
    public float fireRate;
    public float baseSpreadAngle;
    public int currentAmmo;
    public int reserveAmmo;
    public float attackDelayTime;
    public float reloadTime;
    public bool isAutomatic;
    public Color rareColor;
}
