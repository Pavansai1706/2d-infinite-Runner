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

    private AudioManager audioManager;

    private void Start()
    {
        maxJump = maxJumpValue;
        rb = GetComponent<Rigidbody2D>();
        audioManager = AudioManager.Instance; // Cache reference to AudioManager
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (Input.GetKeyDown(KeyCode.Space) && maxJump > 0)
        {
            maxJump--;
            Jump();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && maxJump == 0 && isGrounded)
        {
            Jump();
        }

        if (isGrounded)
        {
            maxJump = maxJumpValue;
        }
        if (!isGrounded)
        {
            audioManager.PlaySound(SoundName.Land); // Play sound using enum
        }
    }

    private void Jump()
    {
        audioManager.PlaySound(SoundName.Jump); // Play sound using enum
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(0, jumpSpeed));
    }
}
