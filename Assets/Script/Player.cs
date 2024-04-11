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

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, whatIsGround);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    void Jump()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(0, JumpSpeed));

    }
}
