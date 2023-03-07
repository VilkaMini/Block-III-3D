using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Movement speed of the character
    [SerializeField] private float turnSpeed = 180f; // Turn speed of the camera
    private Rigidbody rb; // Rigidbody component of the character
    public 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Get the horizontal input
        float verticalInput = Input.GetAxis("Vertical"); // Get the vertical input

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput); // Create a movement vector
        movement = movement.normalized * moveSpeed * Time.fixedDeltaTime; // Scale the movement vector by the speed and fixed time step

        rb.MovePosition(transform.position + movement); // Move the character's position using the Rigidbody component
    }
}
