using System.ComponentModel;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Tooltip("CameraStats scriptable object")]
	[SerializeField] private CameraStats stats;

    [Tooltip("GameObject target of the camera (the object that the camera is looking at)")]
    [SerializeField] private GameObject target;

    void Start()
	{
        if (!stats)
        {
            Debug.LogWarning("CameraStats NULL in CameraFollow script");
            return;
        }

        if (!target)
        {
            Debug.LogWarning("Target NULL in CameraFollow script");
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