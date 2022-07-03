using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    public Rigidbody2D playerRB;
    public Transform groundCheck;
    public LayerMask groundLayer;
    Vector2 vecGravity;

    private float horizontal;
    [SerializeField]private float speed = 5f;
    [SerializeField] private float jumpingPower = 15f;
    [SerializeField] private float fallingPower = 12f;
    private bool isFacingRight = true;
    private void Start()
    {
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
    }
    private void Update()
    {
        playerRB.velocity = new Vector2(horizontal * speed, playerRB.velocity.y);
        if (isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);    
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpingPower);
            Debug.Log("Jump");
        }
         if (context.canceled && playerRB.velocity.y > 0f)
        {
            playerRB.velocity -= new Vector2(playerRB.velocity.x, playerRB.velocity.y * fallingPower);
        }

        
    }
}
