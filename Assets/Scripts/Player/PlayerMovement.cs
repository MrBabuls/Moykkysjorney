
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public ParticleSystem dust;
    public float speed = 400;
    public float jumpForce = 5;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Rigidbody2D playerRB;
    public Animator animator;

    private PlayerControls controls;
    private float direction = 0;
    private bool isFacingRight = true;
    private bool isGrounded;
    private int numberOfJump = 0;



    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        controls.Land.Move.performed += context =>
        {
            direction = context.ReadValue<float>();
        };

        controls.Land.Jump.performed += context => Jump();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        animator.SetBool("IsGrounded", isGrounded);

        playerRB.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, playerRB.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(direction));

        if(isFacingRight && direction < 0f ||  !isFacingRight && direction > 0f)
        {
            Flip();
        }
    }

    void Flip()
    {
        CreateDust();
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    void Jump()
    {
        if (isGrounded)
        {
            CreateDust();
            numberOfJump = 0;
            if (!playerRB)
            {
                return;
            }
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            numberOfJump++;
            AudioManager.instance.Play("FirstJump");
        }
        else 
        {
            if(numberOfJump == 1)
            {
                if (!playerRB)
                {
                    return;
                }
                    playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
                numberOfJump++;
                AudioManager.instance.Play("SecondJump");
            }
        }

    }
    void CreateDust()
    {
        dust.Play();
    }
}
