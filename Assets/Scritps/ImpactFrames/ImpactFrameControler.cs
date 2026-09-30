using UnityEngine;

public class ImpactFrameController : MonoBehaviour
{
    [SerializeField] private ParticleSystem impactParticleSystem;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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