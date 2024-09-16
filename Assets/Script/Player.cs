using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float JumpSpeed;
    private Rigidbody2D rb;

    [SerializeField] private Transform GroundCheck;
    [SerializeField] private float CheckRadius;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private bool isGrounded;

    [SerializeField] private int maxJumpValue;
    int maxJump;

    private void Start()
    {
        maxJump = maxJumpValue;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, whatIsGround);

        if (Input.GetKeyDown(KeyCode.Space) && maxJump > 0 )
        {
            maxJump--;
            Jump();
        }
        else if(Input.GetKeyDown(KeyCode.Space) && maxJump == 0 && isGrounded)
        {
            Jump();
        }

        if (isGrounded)
        {
            maxJump = maxJumpValue;
        }

    }
    void Jump()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(0, JumpSpeed));

    }
}
