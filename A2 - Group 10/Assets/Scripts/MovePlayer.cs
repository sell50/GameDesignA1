using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody rb;

    private const float PlayerSpeed = 80.0f;
    private float jumpHeight = 6.0f;

    private Vector3 playerVelocity;

    private bool canDoubleJump;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        playerVelocity = new Vector3(horizontal, 0f, vertical);
        if (playerVelocity.magnitude > 1) playerVelocity.Normalize();
        rb.MovePosition(transform.position + playerVelocity * Time.deltaTime * PlayerSpeed);
    }

    private void FixedUpdate()
    {
        if (isGrounded) canDoubleJump = true;
        
        if ((isGrounded || canDoubleJump) && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
            if (!isGrounded) canDoubleJump = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Ground")) return;
        Debug.Log("On Ground");
        isGrounded = true;
    }

    private void OnCollisionExit(Collision other)
    {
        if (!other.gameObject.CompareTag("Ground")) return;
        Debug.Log("In Air");
        isGrounded = false;
    }
    
}
