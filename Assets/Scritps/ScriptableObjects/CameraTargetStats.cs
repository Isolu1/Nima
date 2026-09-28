using UnityEngine;

[CreateAssetMenu(fileName = "CameraTargetStatsSO", menuName = "ScriptableObjects/CameraTargetStatsSO")]
public class CameraTargetStats : ScriptableObject
{
    public float maxForwardSpeed;   
    public float maxBackwardSpeed;

    public float maxPlayerDistance;
}
