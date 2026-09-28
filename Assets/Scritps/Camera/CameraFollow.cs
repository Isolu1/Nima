using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField] private CameraStats stats;

	[SerializeField] private GameObject target;

    private Vector3 velocity;

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


        Vector3 camPosWithPlayer = target.transform.InverseTransformPoint(transform.position);

        if (camPosWithPlayer.z > 0f)
        {
            Debug.Log("Cam is Forward Player");
        }
        else
        {
            Debug.Log("Cam is Backward Player");
        }

        //Debug.Log(camPosWithPlayer.z);
        

        //Vector3 newPos = target.transform.position + stats.offsetPos;

        transform.position = target.transform.position + stats.offsetPos;
        //Vector3.SmoothDamp(transform.position, newPos, ref velocity, 1);

    }
}