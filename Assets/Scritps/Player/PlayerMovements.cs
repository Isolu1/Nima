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
        Move();
    }

    private void Move()
    {
        moveImput = GameInputs.Instance.playerMoveAction.ReadValue<Vector2>();

        direction = new Vector3(moveImput.x, 0, moveImput.y);

        playerStates.isMoving = direction.sqrMagnitude > 0.01f;

        if (playerStates.isMoving)
        {
            // rotation
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, playerStats.rotationSpeed * Time.deltaTime);

            // movements
            cc.Move(direction * playerStats.speed * Time.deltaTime);
        }
    }
}