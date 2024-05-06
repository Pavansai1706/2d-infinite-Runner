using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpSpeed;
    private Rigidbody2D rb;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask whatIsGround;
    private bool isGrounded;

    [SerializeField] private int maxJumpValue;
    private int maxJump;
    private const string GROUND = "Ground";

    private AudioManager audioManager;

    private void Start()
    {
        maxJump = maxJumpValue;
        rb = GetComponent<Rigidbody2D>();
        audioManager = AudioManager.Instance; // Cache reference to AudioManager
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (maxJump > 0 || isGrounded)
            {
                maxJump--;
                Jump();
            }
        }

        if (!isGrounded && IsJumping())
        {
            CheckGround(); // Ground check only when player jumps
        }
    }

    private bool IsJumping()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (!isGrounded)
        {
            audioManager.PlaySound(SoundName.Land); // Play sound using enum
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND))
        {
            isGrounded = true;
            maxJump = maxJumpValue;
        }
    }


    private void Jump()
    {
        audioManager.PlaySound(SoundName.Jump); // Play sound using enum
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(0, jumpSpeed));
    }
}
