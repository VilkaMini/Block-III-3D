using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewCameraControl : MonoBehaviour
{
    private Transform focalPoint;
    public Camera c;
    private Transform cam;
    public JoyStickController joystick;

    // Internal variables
    private float rotationY;
    private float rotationX;
    private float horizontalAddition;
    private float verticalAddition;
    private float fovVal =  60;

    // Moving bools
    public bool movingLeft;
    public bool movingRight;
    public bool movingUp;
    public bool movingDownt;

    // External
    public float cameraSpeed = 0.5f;
    public float cameraMoveSpeed = 2f;
    public int cameraDeadZone = 20;
    public float zoomSens = 20;

    // Start is called before the first frame update
    void Start()
    {
        // Define gameobjects
        focalPoint = this.transform;
        cam = c.transform;

        // Curso settings
        Cursor.visible= false;
        Cursor.lockState= CursorLockMode.Locked;

        // Set initial rotation of camera
        rotationY = -120;
    }

    // Update is called once per frame
    void Update()
    {
        // Run logic
        CameraSpin();
        CameraTilt();
        CameraMove();
        CameraZoom();
    }

    // Horizontal camera spin 
    private void CameraSpin()
    {
        float horizontalMove =  joystick.horizontal * cameraSpeed * 0.2f;
        rotationY += -horizontalMove;
        focalPoint.rotation = Quaternion.Euler(rotationX, rotationY, 0);
    }

    // Vertical camera tilts
    private void CameraTilt()
    {
        float verticalMove =  joystick.vertical * cameraSpeed * 0.2f;

        // Check for rotation before applying
        var RotCheckVal = rotationX + verticalMove;
        if (-10 <= RotCheckVal && RotCheckVal <= 10){ rotationX += verticalMove;}

        focalPoint.rotation = Quaternion.Euler(rotationX, rotationY, 0);
    }

    // Move Camera inside the focal point
    private void CameraMove()
    {
        // Check for deadzones
        //var RotTempValX = horizontalAddition + viewJoystick.Horizontal * cameraMoveSpeed;
        //var RotTempValY = verticalAddition + viewJoystick.Vertical * -cameraMoveSpeed;
        //if (-cameraDeadZone <= RotTempValX && RotTempValX <= cameraDeadZone) { horizontalAddition += viewJoystick.Horizontal * cameraMoveSpeed; }
        //if (-cameraDeadZone <= RotTempValY && RotTempValY <= cameraDeadZone) { verticalAddition += viewJoystick.Vertical * -cameraMoveSpeed; }

        cam.rotation = Quaternion.Euler(rotationX + verticalAddition, rotationY + horizontalAddition, 0);
    }

    // Zoom in and out
    private void CameraZoom()
    {
        // Get mouse input
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        // Check for max zoom out
        var TempZoomVal = fovVal + scroll * -zoomSens;
        if (20 <= TempZoomVal && TempZoomVal <= 60) { fovVal += scroll * -zoomSens; }

        // Change FOV for zoom
        c.fieldOfView = fovVal;
    }
}
