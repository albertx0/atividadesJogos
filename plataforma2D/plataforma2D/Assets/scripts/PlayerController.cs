using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public int score = 0;
    public int scoreToNextLevel = 3;
    public string nextLevel;
	public AudioSource deathSound;
	public UIManager uiManager;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;
    private float move;
	private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isDead) return;

        Keyboard keyboard = Keyboard.current;
        if (keyboard == null) return;

        move = 0f;
        if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed)
            move = 1f;
        else if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed)
            move = -1f;

        if (groundCheck != null)
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        anim.SetFloat("speed", Mathf.Abs(move));
        anim.SetBool("isJumping", !isGrounded);
        if (move > 0)
            spriteRenderer.flipX = false;
        else if (move < 0)
            spriteRenderer.flipX = true;

        if (keyboard.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);
    }

    public void Die()
    {
        if (isDead) return;

        isDead = true;

        rb.linearVelocity = Vector2.zero;

        deathSound.Play();

        GetComponent<SpriteRenderer>().enabled = false;

        SceneManager.LoadScene("Cderrota");
    }

	private void RestartScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

    public void AddScore(int value)
    {
        score += value;
		uiManager.UpdateScore(score);
        Debug.Log("Frangos Coletados: " + score);

        if (score >= scoreToNextLevel)
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}
