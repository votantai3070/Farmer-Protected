using UnityEngine;
[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon/WeaponData")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public enum WeaponType
    {
        Rifle,
        Pistol,
        Shotgun,
        Throw
    }
    public WeaponType weaponType;
    public string ingameSprite;
    public string bulletSprite;
    public string UISprite;
    public int firstDamage;
    public int lastDamage;
    public float range;
    public float speed;
    public float criticalChange;
    public float criticalDamage;
    public float stamina;
    public int magazineSize;
    public int currentAmmo;
    public int reserveAmmo;
    public float attackDelayTime;
    public float reloadTime;
    public bool isAutomatic;
    public Color rareColor;
}
