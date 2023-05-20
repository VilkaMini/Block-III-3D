using UnityEngine;

public class FloatingJoystickController : JoyStickController
{
    // Joystick object
    public GameObject joystickCircle;

    private void FixedUpdate()
    {
        // If dragging and if touch is locked
        if (dragging && initialTouchRecorded)
        {
            // Change the start position
            startPos = initialTouch;
            joystickCircle.SetActive(true);
        }
        else
        {
            joystickCircle.SetActive(false);
        }
    }
}
