using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField] private CameraStats stats;

	[SerializeField] private GameObject target;

    void Start()
	{
        if (!stats)
        {
            Debug.LogWarning("CameraStats NULL in CameraFollow Script");
            return;
        }

        transform.position = target.transform.position + stats.offsetPos;
		transform.rotation = Quaternion.Euler(stats.offsetRot);
	}

	void LateUpdate()
    { 
        Quaternion targetRotation = target.transform.rotation;
        transform.position = target.transform.position + stats.offsetPos;
    }
}