using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewCameraControl : MonoBehaviour
{
    private Transform focalPoint;
    public Camera c;
    private Transform cam;

    // Internal variables
    private float rotationY;
    private float rotationX;
    private float horizontalAddition;
    private float verticalAddition;
    private float fovVal =  60;

    // External
    public bool lockView = false;
    public float cameraSpeed = 0.5f;
    public float cameraMoveSpeed = 2f;
    public int cameraDeadZone = 20;
    public float zoomSens = 20;

    // Start is called before the first frame update
    void Start()
    {
        // Set camera lock action
        Actions.OnCameraLock += CameraLock;

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
        float horizontalMove = Input.GetAxis("Horizontal")  * cameraSpeed;
        if (!lockView)
        {
            rotationY += -horizontalMove;
            focalPoint.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        }
    }

    // Vertical camera tilts
    private void CameraTilt()
    {
        float verticalMove = Input.GetAxis("Vertical") * cameraSpeed * 0.2f;
        if (!lockView)
        {
            // Check for rotation before applying
            var RotCheckVal = rotationX + verticalMove;
            if (-10 <= RotCheckVal && RotCheckVal <= 10){ rotationX += verticalMove;}

            focalPoint.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        }
    }

    // Move Camera inside the focal point
    private void CameraMove()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Check for deadzones
        var RotTempValX = horizontalAddition + mouseX * cameraMoveSpeed;
        var RotTempValY = verticalAddition + mouseY * -cameraMoveSpeed;
        if (-cameraDeadZone <= RotTempValX && RotTempValX <= cameraDeadZone) { horizontalAddition += mouseX * cameraMoveSpeed; }
        if (-cameraDeadZone <= RotTempValY && RotTempValY <= cameraDeadZone) { verticalAddition += mouseY * -cameraMoveSpeed; }

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

    private void CameraLock()
    {
        lockView = !lockView;
    }

    private void ActionModeOn()
    {

    }
}
