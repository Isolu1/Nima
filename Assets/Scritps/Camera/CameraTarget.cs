using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraTarget : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private bool isForwardPlayer = false;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
        transform.position = player.transform.position;
	}

	// Update is called once per frame
	void Update()
	{

        Vector3 posWithPlayer = player.transform.InverseTransformPoint(transform.position);

        if (posWithPlayer.z > 0f)
        {
            isForwardPlayer = true;
            Debug.Log("Cam is Forward Player");
        }
        else
        {
            isForwardPlayer = false;
            Debug.Log("Cam is Backward Player");
        }
    }
}
