using UnityEngine;

[CreateAssetMenu(fileName = "CameraStats", menuName = "ScriptableObjects/CameraStatsSO")]
public class CameraStats : ScriptableObject
{
    public Vector3 offsetPos;
    public Vector3 offsetRot;
    public float smoothTime;
}
