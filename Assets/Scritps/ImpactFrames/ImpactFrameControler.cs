using UnityEngine;

public class ImpactFrameController : MonoBehaviour
{
    [Tooltip("Gameobject VFX that should be played")]
    [SerializeField] private ParticleSystem impactParticleSystem;

    [Tooltip("PlayerMovements script from Player gameObject")]
    [SerializeField] private PlayerMovements playerMovements;

    [Tooltip("CameraTarget script from CameraTarget gameObject")]
    [SerializeField] private CameraTarget cameraMovements;

    [Tooltip("VFX lifetime")]
    [SerializeField] private float vfxLifetime = 0.3f;
    private float timer = 0f; // Timer count
    private bool isPlayingVFX = false; // Is the VFX actually playing

    private void Start()
    {
        if (!impactParticleSystem)
        {
            Debug.LogWarning("impactParticleSystem NULL in ImpactFrameController script");
            return;
        }

        if (!playerMovements)
        {
            Debug.LogWarning("playerMovements NULL in ImpactFrameController script");
            return;
        }

        if (!cameraMovements)
        {
            Debug.LogWarning("cameraMovements NULL in ImpactFrameController script");
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

            if (timer >= vfxLifetime)
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