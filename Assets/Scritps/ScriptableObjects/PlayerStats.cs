using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatsSO", menuName = "ScriptableObjects/PlayerStatsSO")]
public class PlayerStats : ScriptableObject
{
    [Tooltip("Speed of the player")]
    public float speed;

    [Tooltip("Multiplier to add to speed when sprinting")]
    public float sprintMultiplier;

    [Tooltip("Rotation speed of the player")]
    public float rotationSpeed;
}
