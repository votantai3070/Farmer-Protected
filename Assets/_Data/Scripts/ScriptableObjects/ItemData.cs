using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public int value;
    public float timeLimit; // For items like speed boost
}

