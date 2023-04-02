using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Movement variables
    [Header("Movement")]
    public float moveSpeed;
    private float moveSpeedTemp;
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump = true;
    public Transform orientation;

    // Ground Check variables
    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    // Input variables
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    Rigidbody rb;

    // UI
    public GameObject canvas;

    void Start()
    {
        moveSpeedTemp = moveSpeed;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation= true;
    }

    void Update()
    {   
        // Open menu
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Enable or disable canvas
            canvas.SetActive(canvas.activeSelf == true ? false : true);
        }

        // Turn of movement
        if (canvas.activeSelf == false)
        {
            // Movement input
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");

            // Jump input
            if (Input.GetKey(KeyCode.Space) && readyToJump && grounded)
            {
                readyToJump = false;
                Jump();
                Invoke(nameof(ResetJump), jumpCooldown);
            }

            MovePlayer();
        }

        // Control drag and speed
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        rb.drag = grounded ? groundDrag : 0;
    }

    // Don't get stuck on walls
    private void OnCollisionStay(Collision collision)
    {
        if (!grounded) {
            moveSpeed = 0.1f;
        }
        else
        {
            moveSpeed = moveSpeedTemp;
        }
    }

    // Movement of player
    private void MovePlayer()
    {
        // Control movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        moveDirection.y = 0;
        // On Ground
        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        // in Air
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
        
    }

    // Jumping
    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    // Reseting jump after cooldown
    private void ResetJump()
    {
        readyToJump = true;
    }
}
