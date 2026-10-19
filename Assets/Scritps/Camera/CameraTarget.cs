using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Playables;
using static UnityEngine.GraphicsBuffer;

public class CameraTarget : MonoBehaviour
{
    [Tooltip("CameraTargetStats scriptable object")]
    [SerializeField] private CameraTargetStats cameraTargetStats;

    [Tooltip("PlayerStats scriptable object")]
    [SerializeField] private PlayerStats playerStats;

    [Tooltip("Player GameObject")]
    [SerializeField] private GameObject player;

    [Tooltip("target GameObject of this target (the object that the target chase)")]
    [SerializeField] private Transform target;

    private PlayerStates playerStates; // PlayerStates script
    private bool isForwardPlayer = false; // Is this object forward the player or not
    private Vector3 velocity; // velocity for "SmoothDamp()"
    private float cameraSpeed; // Speed of the camera target
    private float distanceToPlayer = 0;
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
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        if (!playerStates.isMoving)
        {
            if (GameInputs.Instance.isMovePlayerAction)
            {
                if (distanceToPlayer >= cameraTargetStats.maxPlayerDistance && isForwardPlayer)
                {
                    transform.position = target.position;
                }
                velocity = Vector3.zero;
                return;
            }
            else
            {
                transform.position = Vector3.SmoothDamp(transform.position, transform.position, ref velocity, cameraTargetStats.stopSmoothTime);
                return;
            }
        }


        if (isForwardPlayer)
        {
            if (distanceToPlayer / 2 > cameraTargetStats.maxPlayerDistance)
            {
                transform.position = target.position;
            }
            else if (distanceToPlayer >= cameraTargetStats.maxPlayerDistance)
            {
                cameraSpeed = playerStats.speed;
            }
            else
            {
                float ratio = Mathf.Clamp01(distanceToPlayer / cameraTargetStats.maxPlayerDistance);
                cameraSpeed = Mathf.Lerp(cameraTargetStats.maxBackwardSpeed, playerStats.speed, ratio);
            }
        }
        Vector3 nextPos = transform.position + transform.forward * (isForwardPlayer ? cameraSpeed : cameraTargetStats.maxBackwardSpeed)
                                                                 * (playerStates.isSprinting ? playerStats.sprintMultiplier : 1f);
        transform.position = Vector3.SmoothDamp(transform.position, nextPos, ref velocity, cameraTargetStats.smoothTime);
    }
}
