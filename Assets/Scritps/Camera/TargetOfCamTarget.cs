using UnityEngine;

public class TargetOfCamTarget : MonoBehaviour
{
    [SerializeField] private CameraTargetStats stats;

    void Start()
	{
        if (!stats)
        {
            Debug.LogWarning("CameraTargetStats NULL in TargetOfCamTarget script");
            return;
        }

        Vector3 localPos = transform.localPosition;
        localPos.z = stats.maxPlayerDistance;
        transform.localPosition = localPos;
    }
}
