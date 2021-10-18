using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private CharacterController controller;

    public float playerSpeed = 6.0f;
    private Vector3 playerVelocity;

    private float gravity = -9.81f;

    private float turnSmoothTime = 0.1f;

    private float turnSmoothVelocity;
    private float jumpHeight = 2.0f;
    private bool jump;
    private int jumpNo;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (controller.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0;
        }
        
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        var direction = new Vector3(horizontal, 0, vertical).normalized;
        if (direction.magnitude >= 0.1)
        {
            var targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            var moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * playerSpeed * Time.deltaTime);
        }
        
        if (Input.GetButtonDown("Jump"))
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            /*//isGrounded doesn't work
            if (controller.isGrounded)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
                jumpNo = 0;
            }

            if (!controller.isGrounded && jumpNo <= 2)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
                jumpNo++;
            }*/
        }

        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
