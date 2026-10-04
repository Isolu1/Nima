using UnityEngine;

public class ImpactFrameController : MonoBehaviour
{
    [Tooltip("Gameobject VFX that should be played")]
    [SerializeField] private ParticleSystem impactParticleSystem;

    void Update()
    {
        if (GameInputs.Instance.ImpactFramesAction.IsPressed())
        {
            TriggerEffect();
        }
    }

    private void TriggerEffect()
    {
        if (impactParticleSystem != null)
        {
            impactParticleSystem.Stop();
            impactParticleSystem.Play();
        }
    }
}