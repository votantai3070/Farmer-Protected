using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Character/CharacterData")]
public class CharacterData : ScriptableObject
{
    public string characterName;

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
}
