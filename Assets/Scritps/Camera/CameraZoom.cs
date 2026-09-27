using Unity.Cinemachine;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
	[SerializeField] private CameraStats stats;

	[SerializeField] private CinemachineCamera cinemachineCam;

    private float currentZoom;
    private float targetZoom;
    private float zoomInput;

    private void Start()
    {
        if (!stats)
        {
            Debug.LogWarning("CameraStats NULL in CameraZoom Script");
            return;
        }

        if (!cinemachineCam)
        {
            Debug.LogWarning("Cinemachine Camera is NULL in CameraZoom Script");
            return;
        }

        currentZoom = cinemachineCam.Lens.FieldOfView;
        targetZoom = currentZoom;
    }

    void Update()
	{
        Vector2 scrollValue = GameInputs.Instance.CameraZoomAction.ReadValue<Vector2>();
        zoomInput = scrollValue.y;

        Debug.Log(zoomInput);

        if (zoomInput != 0f)
        {
            targetZoom += zoomInput * stats.zoomSpeed;
            targetZoom = Mathf.Clamp(targetZoom, stats.minZoom, stats.maxZoom);
        }

        currentZoom = Mathf.Lerp(currentZoom, targetZoom, stats.zoomSpeed * Time.deltaTime);

        cinemachineCam.Lens.FieldOfView = currentZoom;
    }
}
