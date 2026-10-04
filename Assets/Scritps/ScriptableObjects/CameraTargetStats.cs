using UnityEngine;

[CreateAssetMenu(fileName = "CameraTargetStatsSO", menuName = "ScriptableObjects/CameraTargetStatsSO")]
public class CameraTargetStats : ScriptableObject
{
    [Tooltip("Max speed of the camera target when it is behind the player (need to be > than the player speed)")]
    public float maxBackwardSpeed;

    [Tooltip("Max distance of the camera target when it is forward the player (for stopping the camera)")]
    public float maxPlayerDistance;

    [Tooltip("Time taken for the camera target to smooth its movement")]
    public float smoothTime;

    [Tooltip("Time taken for the camera target to smooth its movement when its stop")]
    public float stopSmoothTime;
}
