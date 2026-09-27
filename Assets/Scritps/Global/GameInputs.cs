using UnityEngine;
using UnityEngine.InputSystem;

public class GameInputs : MonoBehaviour
{
    [HideInInspector] public static GameInputs Instance;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [Header("Maps")]
    [HideInInspector] public InputActionMap playerMap;
    [HideInInspector] public InputActionMap cameraMap;


    [Header("Player")]
    [HideInInspector] public InputAction playerMoveAction;

    [Header("Camera")]
    [HideInInspector] public InputAction CameraZoomAction;
   
    private void Start()
    {
        // Maps
        playerMap = InputSystem.actions.FindActionMap(Globals.playerMap);
        cameraMap = InputSystem.actions.FindActionMap(Globals.cameraMap);

        // Player
        playerMoveAction = playerMap.FindAction(Globals.playerMove);
        CameraZoomAction = cameraMap.FindAction(Globals.cameraZoom);
    }
}