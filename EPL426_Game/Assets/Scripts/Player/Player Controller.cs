using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float sideSpeed = 5f;
    public float jumpForce = 10f;

    private CharacterController controller;
    private Vector3 moveDirection;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Move forward constantly
        moveDirection.z = forwardSpeed;

        // Check if the player is grounded
        isGrounded = controller.isGrounded;

        // Move sideways
        float horizontalInput = Input.GetAxis("Horizontal");
        moveDirection.x = horizontalInput * sideSpeed;

        // Jump
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            moveDirection.y = jumpForce;
        }

        // Apply gravity
        if (!isGrounded)
        {
            moveDirection.y += Physics.gravity.y * Time.deltaTime;
        }

        // Move the player
        controller.Move(moveDirection * Time.deltaTime);
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
         if(hit.transform.tag == "Obstales")
        {
            PlayerManager.gameOver = true;
        }
    }

}
