using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float sideSpeed = 5f;
    public float jumpForce = 10f;
    public float maxSpeed;

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

        // Move sideways based on touch input
        float horizontalInput = Input.GetAxis("Horizontal");
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 2)
            {
                horizontalInput = -1f; // Move left
            }
            else
            {
                horizontalInput = 1f; // Move right
            }
        }
        moveDirection.x = horizontalInput * sideSpeed;

        // Jump
        if (isGrounded && (Input.GetKeyDown(KeyCode.Space) || TouchJump()))
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

        //Increase Speed
        if(forwardSpeed < maxSpeed)
        {
            forwardSpeed += 0.1f * Time.deltaTime;
        }
        
    }

    // Check for touch-based jump
    bool TouchJump()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began && touch.position.x > Screen.width / 2)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstales")
        {
            PlayerManager.gameOver = true;
            FindObjectOfType<AudioManager>().PlaySound("GameOver");

        }
    }

}
