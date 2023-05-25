using UnityEngine;

public class ViewCameraControl : MonoBehaviour
{
    private Transform focalPoint;
    public Camera c;
    private Transform cam;
    public JoyStickController Joystick;

    // Internal variables
    private float rotationY;
    private float rotationX;
    private float cameraYAddition;
    private float cameraXAddition;
    private float fovVal =  60;

    // External
    public float cameraArmMovementSpeed = 0.5f;
    public float cameraMoveSpeed = 0.2f;
    public float zoomSens = 0.5f;
    public int cameraDeadZone = 20;

    // Arm drive
    private bool armUp = false; 
    private bool armDown = false;
    private bool armLeft = false;
    private bool armRight = false;

    // Zoom bools
    private bool zoomIn = false;
    private bool zoomOut = false;

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
        // Drive arm control
        if (armUp)
        {
            var RotCheckVal = rotationX + cameraArmMovementSpeed;
            if (-10 <= RotCheckVal && RotCheckVal <= 10){
                rotationX += cameraArmMovementSpeed;
            }
        }
        if (armDown)
        {
            var RotCheckVal = rotationX - cameraArmMovementSpeed;
            if (-10 <= RotCheckVal && RotCheckVal <= 10)
            {
                rotationX += -cameraArmMovementSpeed;
            }
        }
        if (armLeft)
        {
            rotationY += cameraArmMovementSpeed;
        }
        if (armRight)
        {
            rotationY += -cameraArmMovementSpeed;
        }
        focalPoint.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        
        // Camera move control
        if (Joystick.horizontal != 0 || Joystick.vertical != 0)
        {
            var RotTempValX = cameraYAddition + Joystick.horizontal * cameraMoveSpeed;
            var RotTempValY = cameraXAddition + Joystick.vertical * -cameraMoveSpeed;
            if (-cameraDeadZone <= RotTempValX && RotTempValX <= cameraDeadZone) { cameraYAddition += Joystick.horizontal * cameraMoveSpeed; }
            if (-cameraDeadZone <= RotTempValY && RotTempValY <= cameraDeadZone) { cameraXAddition += Joystick.vertical * -cameraMoveSpeed; }

            cam.rotation = Quaternion.Euler(rotationX + cameraXAddition, rotationY + cameraYAddition, 0);
        }

        // Zoom in and out control
        if (zoomIn)
        {
            var TempZoomVal = fovVal -zoomSens;
            if (20 <= TempZoomVal) { fovVal += -zoomSens; }
        }
        if (zoomOut)
        {
            var TempZoomVal = fovVal + zoomSens;
            if (60 >= TempZoomVal) { fovVal += zoomSens; }
        }
        c.fieldOfView = fovVal;
    }

    // Arm Drive boolean changers for buttons
    public void ArmDriveUp(int value)
    {
        if (value == 1) { armUp = true; }
        else { armUp = false; }
    }

    public void ArmDriveDown(int value)
    {
        if (value == 1) { armDown = true; }
        else { armDown = false; }
    }

    public void ArmDriveLeft(int value)
    {
        if (value == 1) { armLeft = true; }
        else { armLeft = false; }
    }

    public void ArmDriveRight(int value)
    {
        if (value == 1) { armRight = true; }
        else { armRight = false; }
    }

    // Zoom buttons
    public void ZoomIn(int value)
    {
        if (value == 1) { zoomIn = true; }
        else { zoomIn = false; }
    }
    public void ZoomOut(int value)
    {
        if (value == 1) { zoomOut = true; }
        else { zoomOut = false; }
    }

}
