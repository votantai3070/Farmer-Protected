using UnityEngine;
[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon/WeaponData")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public enum WeaponType
    {
        Gun,
        Throw
    }
    public WeaponType weaponType;
    public string ingameSprite;
    public string UISprite;
    public int firstDamage;
    public int lastDamage;
    public float range;
    public float speed;
    public float criticalChange;
    public float criticalDamage;
    public float stamina;
    public int currentAmmo;
    public int reserveAmmo;
    public float attackDelayTime;
    public Color rareColor;
}
