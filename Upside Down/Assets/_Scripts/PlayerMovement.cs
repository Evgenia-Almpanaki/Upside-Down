using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float jumpSpeed = 1f;
    [SerializeField] private Transform groundCheckTF;
    [SerializeField] private LayerMask groundLayerMask;

    private new Rigidbody2D rigidbody;
    private float xMovement;
    private bool isGrounded = false;
    
    private Collider2D[] groundColliders = new Collider2D[10];

    void Awake()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckIfGrounded();
        MoveHorizontal(); 
    }

    /// <summary>
    /// Check if the player is grounded.
    /// </summary>
    private void CheckIfGrounded()
    {
        isGrounded = Physics2D.OverlapCircleNonAlloc(groundCheckTF.position, .1f, groundColliders, groundLayerMask) > 0;
    }

    /// <summary>
    /// Perform Jump.
    /// </summary>
    void Jump()
    {
        if (!isGrounded) return;

        Vector2 tempVel = rigidbody.velocity;
        tempVel.y += rigidbody.gravityScale * jumpSpeed;
        rigidbody.velocity = tempVel;
    }

    /// <summary>
    /// Perform horizontal movement.
    /// </summary>
    void MoveHorizontal()
    {
        Vector2 tempVel = rigidbody.velocity;
        tempVel.x = xMovement * speed;
        if (!isGrounded && tempVel.y == 0)
        {
            tempVel.y = 1f;
        }
        rigidbody.velocity = tempVel;
    }

    /// <summary>
    /// Jump trigger function - called by the Input System.
    /// </summary>
    /// <param name="input"></param>
    public void OnJump(InputAction.CallbackContext input)
    {
        if (input.started)
        {
            Jump();
        }
    }

    /// <summary>
    /// Move trigger function - called by the Input System.
    /// </summary>
    /// <param name="input"></param>
    public void OnMove(InputAction.CallbackContext input)
    {
        xMovement = input.ReadValue<Vector2>().x;
    }
}
