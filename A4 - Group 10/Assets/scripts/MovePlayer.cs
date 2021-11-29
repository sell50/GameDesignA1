using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{


    private float moveSpeed=5;
    private Vector3 directionZ;
    private Vector3 directionX;
    private Vector3 velocity;
    private bool isGrounded;
    [SerializeField]private float groundCheckDistance;
    [SerializeField]private LayerMask groundMask;
    private CharacterController controller;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpheight;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();    
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
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
    }
}