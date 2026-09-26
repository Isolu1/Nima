using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatsSO", menuName = "ScriptableObjects/PlayerStatsSO")]
public class PlayerStatsSO : ScriptableObject
{
    [Header("Mouvements")]
    public float speed = 5f;
    public float rotationSpeed = 1000f;
}
