using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

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


    [Header("Player")]
    [HideInInspector] public InputAction playerMoveAction;
    [HideInInspector] public InputAction playerSprintAction;
    [HideInInspector] public InputAction ImpactFramesAction;
   
    private void Start()
    {
        // Maps
        playerMap = InputSystem.actions.FindActionMap(Globals.playerMap);

        // Player
        playerMoveAction = playerMap.FindAction(Globals.playerMove);
        playerSprintAction = playerMap.FindAction(Globals.playerSprint);
        ImpactFramesAction = playerMap.FindAction(Globals.impactFrames);

        ImputsVerifications();
    }

    private void ImputsVerifications()
    {
        if (playerMap == null)
        {
            Debug.LogWarning("playerMap NULL in GameInputs script");
            return;
        }

        if (playerMoveAction == null)
        {
            Debug.LogWarning("playerMoveAction NULL in GameInputs script");
            return;
        }

        if (playerSprintAction == null)
        {
            Debug.LogWarning("playerSprintAction NULL in GameInputs script");
            return;
        }

        if (ImpactFramesAction == null)
        {
            Debug.LogWarning("ImpactFramesAction NULL in GameInputs script");
            return;
        }
    }
}