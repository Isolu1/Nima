using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private PlayerStats stats;

    public bool isMoving { get; private set; }

    private CharacterController cc;
    private Vector2 input;
    private Vector3 direction;

    void Start()
    {
        if (!stats)
        {
            Debug.LogWarning("PlayerStats NULL in PlayerMovements script");
            return;
        }

        cc = GetComponent<CharacterController>();

        if (!cc)
        {
            Debug.LogWarning("CharacterController is NULL in PlayerMovements script");
            return;
        }
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        input = GameInputs.Instance.playerMoveAction.ReadValue<Vector2>();

        direction = new Vector3(input.x, 0, input.y);

        isMoving = direction.sqrMagnitude > 0.01f;

        if (isMoving)
        {
            // rotation
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, stats.rotationSpeed * Time.deltaTime);

            // movements
            cc.Move(direction * stats.speed * Time.deltaTime);
        }
    }
}