using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; 
    [SerializeField] private float mouseSensitivity = 2f;
    float cameraVerticalRotation;
    public Transform player;

    void Start()
    {

    }

    void Update()
    {

        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Vertical rotation of camera
        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

        player.Rotate(Vector3.up * inputX);


        //Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput); // Create a movement vector
        //movement = movement.normalized * moveSpeed * Time.fixedDeltaTime; // Scale the movement vector by the speed and fixed time step

    }
}
