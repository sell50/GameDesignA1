using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour, PlayerControls.IMovementActions
{
    [Header("Movement Values")]
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpheight;
    [SerializeField] private float horizontalInput;

    private Vector3 _direction;
    private Vector3 _velocity;
    private float yVelocity;
    private bool isGrounded;
    [SerializeField]private float groundCheckDistance;
    [SerializeField]private LayerMask groundMask;
    private CharacterController controller;
    
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Movement()
    {
        isGrounded = controller.isGrounded;

        if (controller.isGrounded)
        {
            _velocity = _direction * moveSpeed;
        }
        else
        {
            _velocity.y -= gravity * Time.deltaTime;
        }
        controller.Move(_direction * moveSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    private void Update()
    {
        Movement();
    }

    /*void Move()
    {
        float movez = Input.GetAxis("Vertical");
        float movex = Input.GetAxis("Horizontal");
        directionZ = new Vector3(0, 0, movez);
        directionX = new Vector3(movex, 0, 0);
        directionZ *= moveSpeed;
        directionX *= moveSpeed;
        controller.Move(directionZ* Time.deltaTime);
        controller.Move(directionX * Time.deltaTime);

        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2 * gravity);
        }
        velocity.y = Mathf.Sqrt(jumpheight * -2 * gravity);
                 controller.Move(velocity * Time.deltaTime);
    }*/
    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<Vector2>());
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        //Debug.Log(context.ReadValue<Vector2>().x);
        var dirX = context.ReadValue<Vector2>().x;
        var dirZ = context.ReadValue<Vector2>().y;
        _direction = new Vector3(dirX, 0, dirZ);
    }
}
