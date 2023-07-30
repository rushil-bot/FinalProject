using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMoving : MonoBehaviour
{
    public CharacterController controller;
    public float Speed = 6f;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    public Transform cam;

    public float gravityMultiplier = 1f;
    public float jumpHeight = 2.4f;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDir.normalized * Speed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") )
        {
            Debug.Log("Here");
            direction.y = jumpHeight * 10;

        }

        // Applying Gravity
        /*
        if (controller.isGrounded == false)
        {
            Debug.Log("In teh air!");
            direction.y += Physics.gravity.y * gravityMultiplier;

        }
        */
    }
}

