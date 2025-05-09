using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of the player movement
    Rigidbody rb; // Reference to the Rigidbody3D component
    private Vector3 moveInput; // Store the input for movement

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody2D component attached to the player
    }

    // Update is called once per frame
    void Update()
    {
        GatherInput(); // Gather input from the player
        Look(); // Call the Look function to rotate the player
    }

    void FixedUpdate()
    {
        Move(); // Call the Move function in FixedUpdate for physics calculations
    }

    void GatherInput()
    {
        moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); // Gather input from the player
    }

    void Look()
{
    if (moveInput.sqrMagnitude > 0.01f) // Evita rotar si no hay movimiento significativo
    {
        var relative = moveInput.normalized;
        var rot = Quaternion.LookRotation(relative, Vector3.up);
        transform.rotation = rot;
    }
}
    

    void Move()
    {
        rb.MovePosition(rb.position + (transform.forward * moveInput.magnitude) * speed * Time.fixedDeltaTime); // Move the player based on input
    }
}
