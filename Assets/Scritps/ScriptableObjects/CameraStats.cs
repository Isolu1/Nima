using UnityEngine;

[CreateAssetMenu(fileName = "CameraStatsSO", menuName = "ScriptableObjects/CameraStatsSO")]

public class CameraStats : ScriptableObject
{
    [Header("Zoom")]

    public float maxZoom;
    public float minZoom;
    public float zoomSpeed;
}
