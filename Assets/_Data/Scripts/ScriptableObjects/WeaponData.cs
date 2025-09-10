using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon/WeaponData")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public Sprite sprite;
    public int damage;
    public float range;
    public float speed;
}
