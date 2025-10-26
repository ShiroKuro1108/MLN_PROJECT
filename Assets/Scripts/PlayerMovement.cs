using UnityEditor.Tilemaps;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck; // M?t object r?ng �?t d�?i ch�n player
    public LayerMask groundLayer; // Layer c?a m?t �?t
    public Animator animator;
    private Rigidbody2D rb;
    private bool isGrounded;
    private float moveInput;
    public int facingDirection = 1; // 1: ph?i, -1: tr�i

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Ki?m tra xem c� �ang �?ng tr�n m?t �?t kh�ng
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);
        // 1. Di chuy?n ngang
        moveInput = Input.GetAxisRaw("Horizontal"); // Tr? v? -1 (tr�i), 1 (ph?i), 0 (�?ng y�n)
        if (moveInput > 0 && transform.localScale.x < 0 || moveInput < 0 && transform.localScale.x > 0) 
        {
            Flip();
        }
        
        animator.SetFloat("horizontal", Mathf.Abs(moveInput));
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // 2. Nh?y
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
    void Flip()
    {
        facingDirection *= -1;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}