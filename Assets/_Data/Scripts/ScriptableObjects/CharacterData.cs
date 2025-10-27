using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Character/CharacterData")]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public int level;
    public string description;
    public Color rareColor;
    public enum CharacterType
    {
        Player,
        Enemy
    }

    public CharacterType characterType;
    public string characterSprite;
    public float speed;
    public float maxHealth;
    public float stamina;
    public float range;
    public float dashSpeed;
    public int reward;
    public float dropBulletChange;
    public float dropPotionChange;
    public float dropSpeedChange;
    public float dropMagChange;
}
