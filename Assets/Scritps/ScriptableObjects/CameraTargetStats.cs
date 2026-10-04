using UnityEngine;

[CreateAssetMenu(fileName = "CameraTargetStatsSO", menuName = "ScriptableObjects/CameraTargetStatsSO")]
public class CameraTargetStats : ScriptableObject
{
    [Tooltip("Max speed of the camera target when it is in front the player (need to be > than the player speed)")]
    public float maxForwardSpeed;

    [Tooltip("Max speed of the camera target when it is behind the player (recommended to be > than the maxForwardSpeed)")]
    public float maxBackwardSpeed;

    [Tooltip("Max distance of the camera target when it is forward the player (for stopping the camera)")]
    public float maxPlayerDistance;

    [Tooltip("Time taken for the camera target to smooth its movement")]
    public float smoothTime;
}
