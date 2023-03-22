using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCameraControl : MonoBehaviour
{
    private Transform camera;

    // Internal variables
    private float rotationY;
    private float rotationX;
    private float mouseY;
    private float mouseX;

    // External
    public bool lockActionView = false;
    public float cameraActionSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        camera = this.transform;
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        VerticalMovement();
    }

    private void VerticalMovement()
    {
        mouseX = Input.GetAxis("Mouse Y") * -cameraActionSpeed;
        mouseY = Input.GetAxis("Mouse X") * cameraActionSpeed;

       
    }
}
