using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Vector3 position;
    private CharacterController controller;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movement_v = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
        Debug.Log(movement_v);

        controller.Move(movement_v);
    }
}
