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


    [Header("Player")]
    [HideInInspector] public InputAction playerMoveAction;
    [HideInInspector] public InputAction ImpactFramesAction;
   
    private void Start()
    {
        // Maps
        playerMap = InputSystem.actions.FindActionMap(Globals.playerMap);

        // Player
        playerMoveAction = playerMap.FindAction(Globals.playerMove);
        ImpactFramesAction = playerMap.FindAction(Globals.impactFrames);
    }
}