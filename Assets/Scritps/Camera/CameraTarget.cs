using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraTarget : MonoBehaviour
{
    [SerializeField] private CameraTargetStats stats;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform target;

    private PlayerMovements playerMovements;
    private bool isForwardPlayer = false;

	void Start()
	{
        if (!stats)
        {
            Debug.LogWarning("CameraTargetStats NULL in CameraTarget script");
            return;
        }

        if (!player)
        {
            Debug.LogWarning("Player is NULL in CameraTarget script");
            return;
        }

        if (!target)
        {
            Debug.LogWarning("Target is NULL in CameraTarget script");
            return;
        }

        playerMovements = player.GetComponent<PlayerMovements>();

        transform.position = player.transform.position;
	}

	void Update()
	{

        Vector3 posWithPlayer = player.transform.InverseTransformPoint(transform.position);

        if (posWithPlayer.z > 0f)
        {
            isForwardPlayer = true;
            Debug.Log("Cam is Forward Player");
        }
        else
        {
            isForwardPlayer = false;
            Debug.Log("Cam is Backward Player");
        }

        Vector3 directionToTarget = target.position - transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = targetRotation;

        MoveCamTarget();
    }

    private void MoveCamTarget()
    {
        if (!playerMovements.isMoving)
        {
            return;
        }

        float sqrDistanceToPlayer = (transform.position - player.transform.position).sqrMagnitude;
        float sqrMaxDistance = stats.maxPlayerDistance * stats.maxPlayerDistance;

        if (sqrDistanceToPlayer >= sqrMaxDistance && isForwardPlayer)
        {
            return;
        }

        if (isForwardPlayer)
        {
            Vector3 nextPos = transform.position + transform.forward * stats.maxForwardSpeed * Time.deltaTime;
            transform.position = nextPos;
        }
        else
        {
            Vector3 nextPos = transform.position + transform.forward * stats.maxBackwardSpeed * Time.deltaTime;
            transform.position = nextPos;
        }
    }
}
