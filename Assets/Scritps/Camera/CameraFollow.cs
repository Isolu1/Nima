using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private CameraStats stats;
    [SerializeField] private Transform target;

    private Vector3 velocity;

    void Update()
    {
        if (target == null)
        {
            Debug.LogWarning("Camera Target NULL");
            return;
        }

        Vector3 newPos = target.position + stats.offsetPos;

        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, stats.smoothTime);
        transform.rotation = Quaternion.Euler(stats.offsetRot);
    }
}