using UnityEngine;

[CreateAssetMenu(fileName = "CameraStatsSO", menuName = "ScriptableObjects/CameraStatsSO")]
public class CameraStats : ScriptableObject
{
    [Tooltip("Offset camera position relative to the target that it looking at")]
    public Vector3 offsetPos;

    [Tooltip("Offset camera rotation relative to the target that it looking at (to focus the target)")]
    public Vector3 offsetRot;
}
