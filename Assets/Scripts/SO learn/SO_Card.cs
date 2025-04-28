using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu (menuName = "Profile/Card")]
public class SO_Card : ScriptableObject
{
    [Header("Character Information")]
    public string Name;
    public string Description;
    public Type ElementalType;

    [Header("Character Stats")]
    public string Cost;
    public string Health;
    public string ATK;

    [Space, ShowAssetPreview]
    public Sprite CharacterImage;
}

public enum Type
{
    Normal,
    Fire,
    Water,
    Electric,
    Ice,
    Grass,
    Ground
}
