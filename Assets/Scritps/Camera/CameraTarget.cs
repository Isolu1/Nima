using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using static UnityEngine.GraphicsBuffer;

public class CameraTarget : MonoBehaviour
{
    [Tooltip("CameraTargetStats scriptable object")]
    [SerializeField] private CameraTargetStats cameraTargetStats;

    [Tooltip("PlayerStats scriptable object")]
    [SerializeField] private PlayerStats playerStats;

    [Tooltip("GameObject Player")]
    [SerializeField] private GameObject player;

    [Tooltip("GameObject target of this target (the object that the target chase)")]
    [SerializeField] private Transform target;

    private PlayerStates playerStates; // PlayerStates script
    private bool isForwardPlayer = false; // Is this object forward the player or not
    private Vector3 velocity; // velocity for "SmoothDamp()"

	void Start()
	{
        if (!cameraTargetStats)
        {
            Debug.LogWarning("CameraTargetStats NULL in CameraTarget script");
            return;
        }

        if (!playerStats)
        {
            Debug.LogWarning("PlayerStats NULL in PlayerMovements script");
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

        playerStates = player.GetComponent<PlayerStates>();

        if (!playerStates)
        {
            Debug.LogWarning("PlayerStates is NULL in CameraTarget script (No PlayerStates in Player)");
            return;
        }

        transform.position = player.transform.position;
        velocity = Vector3.zero;
	}

	void Update()
	{

        Vector3 posWithPlayer = player.transform.InverseTransformPoint(transform.position);

        isForwardPlayer = posWithPlayer.z > 0f;

        Vector3 directionToTarget = target.position - transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = targetRotation;

        MoveCamTarget();
    }

    private void MoveCamTarget()
    {
        if (!playerStates.isMoving)
        {
            transform.position = Vector3.SmoothDamp(transform.position, transform.position, ref velocity, cameraTargetStats.smoothTime);
            return;
        }

        float sqrDistanceToPlayer = (transform.position - player.transform.position).sqrMagnitude;
        float sqrMaxDistance = cameraTargetStats.maxPlayerDistance * cameraTargetStats.maxPlayerDistance;

        if (sqrDistanceToPlayer >= sqrMaxDistance && isForwardPlayer)
        {
            return;
        }

        Vector3 nextPos = transform.position + transform.forward * (isForwardPlayer ? cameraTargetStats.maxForwardSpeed : cameraTargetStats.maxBackwardSpeed)
                                                                 * (playerStates.isSprinting ? playerStats.sprintMultiplier : 1f);
        transform.position = Vector3.SmoothDamp(transform.position, nextPos, ref velocity, cameraTargetStats.smoothTime);
    }
}
