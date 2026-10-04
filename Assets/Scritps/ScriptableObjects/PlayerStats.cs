using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatsSO", menuName = "ScriptableObjects/PlayerStatsSO")]
public class PlayerStats : ScriptableObject
{
    [Header("Mouvements")]

    [Tooltip("Speed of the player")]
    public float speed = 5f;

    [Tooltip("Rotation speed of the player")]
    public float rotationSpeed = 1000f;
}
