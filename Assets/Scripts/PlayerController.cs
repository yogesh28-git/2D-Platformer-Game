using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D playerCollider;
    private Rigidbody2D playerBody;
    [SerializeField] private ScoreController scorecontroller;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    private bool isGrounded = false;
    private bool shiftPressed = false;
    private bool jumpPressDown = false;
    private bool ctrlPressed = false;

    [SerializeField] private string NewScene = "Level 2";

    void Awake()
    {
        Debug.Log("Script detected !!!");
    }
    private void Start()
    {
        playerCollider = gameObject.GetComponent<BoxCollider2D>();
        animator = gameObject.GetComponent<Animator>();
        playerBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Inputs
        float horizontal = Input.GetAxisRaw("Horizontal");
        shiftPressed = Input.GetKey(KeyCode.LeftShift);
        jumpPressDown = Input.GetButtonDown("Jump");
        ctrlPressed = (Input.GetKey(KeyCode.LeftControl)) || (Input.GetKey(KeyCode.RightControl));

        PlayerAnimation(horizontal);
        PlayerMovement(horizontal);
    }
    private void PlayerMovement(float horizontal)
    {
        //walk and run
        Vector3 position = transform.position;
        if (shiftPressed)
        {
            position.x += horizontal * speed * Time.deltaTime * 2;  //Run
        }
        else
        {
            position.x += horizontal * speed * Time.deltaTime;     //Walk
        }
        transform.position = position;

        //Jump
        if (jumpPressDown && isGrounded)
        {
            isGrounded = false;
            if (shiftPressed)
            {
                playerBody.AddForce(new Vector2(0f, 1.2f * jumpForce), ForceMode2D.Impulse);    //Running Jump
            }
            else
            {
                playerBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);         //Walking Jump
            }
        }

    }
    

    private void PlayerAnimation(float horizontal)
    {
        if (shiftPressed)                          // For Run animation, I make speed variable > 1.99, Pressing L.Shift
        {
            horizontal = 2 * horizontal;
        }
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        animator.SetBool("Walk_Button", (horizontal != 0 ? true : false));


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
        animator.SetBool("Crouch", ctrlPressed);
        if (ctrlPressed)
        {
            playerCollider.offset = new Vector2(-0.12f, 0.6f);
            playerCollider.size = new Vector2(0.9f, 1.3f);
        }
        else
        {
            playerCollider.offset = new Vector2(0f, 0.95f);
            playerCollider.size = new Vector2(0.6f, 2f);
        }

        //Jump Animation
        animator.SetBool("Jumped", jumpPressDown);
        animator.SetBool("isGrounded", isGrounded);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Death"))              //Death by Falling from a Platform
        {
            animator.SetTrigger("Death");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LevelEnd"))
        {
            Debug.Log("Triggered");
            SceneManager.LoadScene("Level 2");
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
   

}
