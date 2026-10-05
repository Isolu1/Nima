using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerMovements : MonoBehaviour
{
    [Tooltip("PlayerStats scriptable object")]
    [SerializeField] private PlayerStats playerStats;

    private CharacterController cc; // Player CharacterController
    private PlayerStates playerStates; // PlayerStates script
    private Vector2 moveImput; // Movement imput
    private Vector3 direction; // Direction of the player when he moves

    private Vector3 lastMoveDirection; // Last direction movement for deceleration
    private float currentSpeed; // Actual player speed
    private float lastFrameSpeed = 0f; // Player speed at last frame (0f at the first frame of the game)
    private float currentSpeedVelocity; // Velocity for currentSpeed SmoothDamp()
    void Start()
    {
        if (!playerStats)
        {
            Debug.LogWarning("PlayerStats NULL in PlayerMovements script");
            return;
        }

        cc = GetComponent<CharacterController>();
        playerStates = GetComponent<PlayerStates>();

        if (!cc)
        {
            Debug.LogWarning("CharacterController is NULL in PlayerMovements script");
            return;
        }

        if (!playerStates)
        {
            Debug.LogWarning("PlayerStates is NULL in PlayerMovements script");
            return;
        }
    }

    void Update()
    {
        Debug.Log(playerStates.isMoving);
        Move();
    }

    private void Move()
    {
        moveImput = GameInputs.Instance.playerMoveAction.ReadValue<Vector2>();
        if (moveImput == Vector2.zero)
        {
            GameInputs.Instance.isMovePlayerAction = false;
        }
        else
        {
            GameInputs.Instance.isMovePlayerAction = true;
        }

        GameInputs.Instance.isMovePlayerAction = GameInputs.Instance.playerSprintAction.IsPressed();

        direction = new Vector3(moveImput.x, 0, moveImput.y);

        if (direction.sqrMagnitude > 0.01f)
        {
            lastMoveDirection = direction;
        }

        playerStates.isMoving = direction.sqrMagnitude > 0.01f;

        if (playerStates.isMoving)
        {
            // rotation
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, playerStats.rotationSpeed * Time.deltaTime);

            // movements
            float targetSpeed = playerStats.speed * (GameInputs.Instance.isPlayerSprintAction ? playerStats.sprintMultiplier : 1f);
            currentSpeed = Mathf.SmoothDamp(lastFrameSpeed, targetSpeed, ref currentSpeedVelocity, playerStats.sprintSmoothTime);
            lastFrameSpeed = currentSpeed;

            cc.Move(direction * currentSpeed * Time.deltaTime);
        }
        else
        {
            lastFrameSpeed = Mathf.SmoothDamp(lastFrameSpeed, 0f, ref currentSpeedVelocity, playerStats.stopSmoothTime);
            cc.Move(lastMoveDirection * lastFrameSpeed * Time.deltaTime);
        }
    }
}