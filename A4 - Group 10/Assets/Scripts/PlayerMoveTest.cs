using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveTest : MonoBehaviour
{
       [SerializeField] float playerSpeed = 2.0f;
       [SerializeField] float jumpHeight = 3.0f;
       [SerializeField] float gravityValue = -9.81f;
       [SerializeField] float pushPower = 2.0f;
       
       CharacterController controller;
       Vector3 playerVelocity;
       bool groundedPlayer;
       private bool canDoubleJump;
   
       void Awake()
       {
           controller = GetComponent<CharacterController>();
       }
   
       void Update()
       {
           groundedPlayer = controller.isGrounded;
           if (groundedPlayer && playerVelocity.y < 0)
           {
               playerVelocity.y = 0f;
           }

           Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
           controller.Move(Time.deltaTime * playerSpeed * move);
   
           if (move != Vector3.zero)
           {
               gameObject.transform.forward = move;
           }

           if (groundedPlayer)
           {
               canDoubleJump = false;
           }
           // Changes the height position of the player..
           if (Input.GetButtonDown("Jump") && groundedPlayer)
           {
               playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
               if (Input.GetButtonDown("Jump") && canDoubleJump)
               {
                   playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                   canDoubleJump = false;
               }
           }
   
           playerVelocity.y += gravityValue * Time.deltaTime;
           controller.Move(playerVelocity * Time.deltaTime);
       }
}
