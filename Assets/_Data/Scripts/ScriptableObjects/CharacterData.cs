using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Character/CharacterData")]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public int level;
    public string description;
    public enum CharacterType
    {
        Warrior,
        Mage,
        Archer,
        Enemy
    }

    public CharacterType characterType;

    public float speed;
    public float maxHealth;
    public float stamina;
    public float range;
    public float dashSpeed;
    public float dropBulletChange;
    public float dropPotionChange;
    public float dropSpeedChange;
    public float dropMagChange;
}
