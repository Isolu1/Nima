using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 1000f; // per sec in degre

    private CharacterController cc;
    private Vector2 input;
    private Vector3 direction;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        input = GameInputs.Instance.playerMoveAction.ReadValue<Vector2>();

        direction = new Vector3(input.x, 0, input.y);

        if (direction.sqrMagnitude > 0.01f)
        {
            // rotation
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // movements
            cc.Move(direction * speed * Time.deltaTime);
        }
    }
}