using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{

    public float mouseSensitivity = 2f;
    float cameraVerticalRotation;
    public Transform player;

    private void Start()
    {
        // Lock and Hide the Cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
    }
}
