using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    private Vector3 offset; // Offset from the player
    [SerializeField] Transform player; // Reference to the player's transform
    [SerializeField] float smoothSpeed = 0.125f; // Speed of the camera smoothing
    private Vector3 currentVelocity = Vector3.zero;// Current velocity of the camera
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        offset = transform.position - player.position; // Calculate the initial offset
    }

    void Start()
    {
        
    }

    void LateUpdate()
    {
        Vector3 targetPosition = player.position + offset; // Calculate the target position for the camera
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothSpeed); // Smoothly move the camera to the target position
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
