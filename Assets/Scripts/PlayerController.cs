using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Animator playerAnimator;
    private BoxCollider2D playerCollider;
    private Rigidbody2D playerBody;
    private SpriteRenderer playerSpriteRenderer;
    [SerializeField] private UIController scorecontroller;
    [SerializeField] private UIHeart heartScript;

    private float walkSpeed = 3;
    private float runSpeed;
    private Vector2 walkingJump;
    private Vector2 runningJump;
    [SerializeField] private float jumpForce;
    private Color originalColor = new Color(1, 1, 1, 1);
    private Color fadeColor = new Color(1, 1, 1, 0.3f);
    private Vector2 playerColliderOffsetInitial = new Vector2(-0.1f, 0.6f);
    private Vector2 playerColliderSizeInitial = new Vector2(0.9f, 1.3f);
    private Vector2 playerColliderOffsetFinal = new Vector2(0f, 0.9f);
    private Vector2 playerColliderSizeFinal = new Vector2(0.6f, 2f);

    private float horizontalInput;
    private bool isGrounded = false;
    private bool shiftPressed = false;
    private bool jumpPressDown = false;
    private bool ctrlPressed = false;

    private int heartCount = 3;
    private bool hurt = false;
    private float timer = 0f;
    private int timeCount = 1;
    [SerializeField] private string NewScene = "Level 2";

    
    private void Start()
    {
        playerCollider = gameObject.GetComponent<BoxCollider2D>();
        playerAnimator = gameObject.GetComponent<Animator>();
        playerBody = gameObject.GetComponent<Rigidbody2D>();
        playerSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        runSpeed = 2 * walkSpeed;

        runningJump = new Vector2(0f, 1.2f * jumpForce);
        walkingJump = new Vector2(0f, jumpForce);
    }

    void Update()
    {
        //Inputs
        horizontalInput = Input.GetAxisRaw("Horizontal");
        jumpPressDown = Input.GetButtonDown("Jump");
        shiftPressed = Input.GetKey(KeyCode.LeftShift);
        ctrlPressed = (Input.GetKey(KeyCode.LeftControl)) || (Input.GetKey(KeyCode.RightControl));

        PlayerAnimation(horizontalInput);
        PlayerMovement(horizontalInput);

        playerHurt();
    }
    private void PlayerMovement(float horizontal)
    {
        //walk and run
        Vector3 position = transform.position;
        if (shiftPressed)
        {
            position.x += horizontal * runSpeed * Time.deltaTime;  //Run
        }
        else
        {
            position.x += horizontal * walkSpeed * Time.deltaTime;     //Walk
        }
        transform.position = position;

        //Jump
        if (jumpPressDown && isGrounded)
        {
            isGrounded = false;
            if (shiftPressed)
            {
                playerBody.AddForce(runningJump, ForceMode2D.Impulse);    //Running Jump
            }
            else
            {
                playerBody.AddForce(walkingJump, ForceMode2D.Impulse);    //Walking Jump
            }
        }

    }
    

    private void PlayerAnimation(float horizontal)
    {
        if (shiftPressed)                          // For Run animation, I make speed variable > 1.99, Pressing L.Shift
        {
            horizontal = 2 * horizontal;
        }
        playerAnimator.SetFloat("Speed", Mathf.Abs(horizontal));
        playerAnimator.SetBool("Walk_Button", (horizontal != 0 ? true : false));


        //Flipping the player 
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        //Crouch Animation
        playerAnimator.SetBool("Crouch", ctrlPressed);
        if (ctrlPressed)
        {
            playerCollider.offset = playerColliderOffsetFinal;
            playerCollider.size = playerColliderSizeFinal;
        }
        else
        {
            playerCollider.offset = playerColliderOffsetInitial;
            playerCollider.size = playerColliderSizeInitial;
        }

        //Jump Animation
        playerAnimator.SetBool("Jumped", jumpPressDown);
        playerAnimator.SetBool("isGrounded", isGrounded);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Death"))              //Death by Falling from a Platform
        {
            playerAnimator.SetTrigger("Death");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LevelEnd"))
        {
            Debug.Log("Next Level");
            SceneManager.LoadScene(NewScene);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void pickupKey(int keyPoints)
    {
        Debug.Log("Player picked up key");
        scorecontroller.IncreaseScore(keyPoints);
    }
    public void EnemyCollider()
    {
        Debug.Log("Collided with Enemy");
        if (!hurt)
        {
            if (heartCount <= 0)
            {
                playerAnimator.SetTrigger("Death");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                hurt = true;
                playerAnimator.SetTrigger("Hurt");
                Vector3 position = transform.position;
                if (transform.localScale.x > 0)     //throws the player backward by 3 units opposite to the direction it is facing
                    position.x -= 3f;
                else
                    position.x += 3f;
                transform.position = position;

                heartIncrease(false);
            }
        }
    }
    private void playerHurt()
    {
        if (hurt) //Hurt Delay : Blinking effect and player will not be hurt again for 3 seconds
        {
            timer += Time.deltaTime;
            if (timer > (0.3 * timeCount))    //Blink every 0.3 seconds
            {
                if (timeCount % 2 == 0)
                    playerSpriteRenderer.color = originalColor;
                else
                    playerSpriteRenderer.color = fadeColor;
                timeCount++;
            }
            if (timer >= 3)                //waiting 3 seconds
            {
                hurt = false;
                timeCount = 1;
                timer = 0f;
            }
        }
    }

    public void heartIncrease(bool increase)
    {
        if (increase)
        {
            heartCount += 1;
        }
        else
        {
            heartCount -= 1;
        }
        heartScript.HeartController(heartCount);
    }
}
