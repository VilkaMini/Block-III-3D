using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{

    public float mouseSensitivity = 2f;
    float cameraVerticalRotation;
    public Transform player;

    private void Awake()
    {
        //Actions.OnOpenInventory += changeState;
    }

    private void Start()
    {
        // Lock and Hide the Cursor
        Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!Cursor.visible)
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

    void changeState()
    {
        print("Called");
        if (Cursor.visible == true)
        {
            Cursor.visible = false;
            //Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = true;
            //Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void OnDisable()
    {
        // Actions.OnOpenInventory -= changeState;
    }
}
