using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using static UnityEngine.GraphicsBuffer;

public class CameraTarget : MonoBehaviour
{
    [Tooltip("CameraTargetStats scriptable object")]
    [SerializeField] private CameraTargetStats stats;

    [Tooltip("GameObject Player")]
    [SerializeField] private GameObject player;

    [Tooltip("GameObject target of this target (the object that the target chase)")]
    [SerializeField] private Transform target;

    private PlayerState playerStates; // PlayerStates script
    private bool isForwardPlayer = false; // Is this object forward the player or not
    private Vector3 velocity; // velocity for "SmoothDamp()"

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

        playerStates = player.GetComponent<PlayerState>();

        transform.position = player.transform.position;
        velocity = Vector3.zero;
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
        if (!playerStates.isMoving)
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
            Vector3 nextPos = transform.position + transform.forward * stats.maxForwardSpeed;
            transform.position = Vector3.SmoothDamp(transform.position, nextPos, ref velocity, stats.smoothTime);
        }
        else
        {
            Vector3 nextPos = transform.position + transform.forward * stats.maxBackwardSpeed;
            transform.position = Vector3.SmoothDamp(transform.position, nextPos, ref velocity, stats.smoothTime);
        }
    }
}
