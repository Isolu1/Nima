using UnityEngine;

public class ImpactFrameController : MonoBehaviour
{
    [Tooltip("Gameobject VFX that should be played")]
    [SerializeField] private ParticleSystem impactParticleSystem;


    [SerializeField] private PlayerMovements playerMovements;
    [SerializeField] private CameraTarget cameraMovements;
    [SerializeField] private float delayTimer = 0.3f;
    private float timer = 0f;
    private bool isPlayingVFX = false;

    private void Start()
    {
        if (!impactParticleSystem)
        {
            Debug.LogWarning("impactParticleSystem NULL in ImpactFrameController script");
            return;
        }
    }

    void Update()
    {
        if (GameInputs.Instance.ImpactFramesAction.WasPressedThisFrame())
        {
            TriggerEffect();
        }

        if (isPlayingVFX)
        {
            playerMovements.enabled = false;
            cameraMovements.enabled = false;
            timer += Time.deltaTime;

            if (timer >= delayTimer)
            {
                timer = 0f;
                isPlayingVFX = false;
            }
        }
        else
        {
            playerMovements.enabled = true;
            cameraMovements.enabled = true;
        }
    }

    private void TriggerEffect()
    {
        if (impactParticleSystem != null)
        {
            isPlayingVFX = true;
            impactParticleSystem.Stop();
            impactParticleSystem.Play();
        }
    }
}