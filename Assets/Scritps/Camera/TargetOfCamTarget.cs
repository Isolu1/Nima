using UnityEngine;

public class TargetOfCamTarget : MonoBehaviour
{
    [SerializeField] private CameraTargetStats stats;

    void Start()
	{
        Vector3 localPos = transform.localPosition;
        localPos.z = stats.maxPlayerDistance;
        transform.localPosition = localPos;
    }
}
