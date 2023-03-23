using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewCameraControl : MonoBehaviour
{
    private Transform focalPoint;

    // Internal variables
    private float rotationY;
    private float rotationX;
    private float horizontalMove;
    private float verticalMove;

    // External
    public bool lockView = false;
    public float cameraSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        Actions.OnCameraLock += CameraLock;
        focalPoint = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        CameraSpin();
        CameraTilt();
    }

    private void CameraSpin()
    {
        horizontalMove = Input.GetAxis("Horizontal")  * cameraSpeed;
        if (!lockView)
        {
            rotationY += horizontalMove;
            focalPoint.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        }
    }

    private void CameraTilt()
    {
        verticalMove = Input.GetAxis("Vertical") * cameraSpeed * 0.2f;
        if (!lockView)
        {
            var RotCheckVal = rotationX + verticalMove;
            if (-10 <= RotCheckVal && RotCheckVal <= 10){ rotationX += verticalMove;}

            focalPoint.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        }
    }

    private void CameraLock()
    {
        lockView = !lockView;
    }
}
