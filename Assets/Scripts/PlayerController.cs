using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    BoxCollider2D playerCollider;
    Rigidbody2D playerBody;

    public float speed;
    public float jumpForce;
    private bool isGrounded = false;
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
        float horizontal = Input.GetAxisRaw("Horizontal");
        PlayerAnimation(horizontal);
        PlayerMovement(horizontal);
    }
    private void PlayerMovement(float horizontal)
    {   
        //walk and run
        Vector3 position = transform.position;
        if(Input.GetKey(KeyCode.LeftShift))                          
        {
            position.x += horizontal * speed * Time.deltaTime * 2;  //Run
        }
        else
        {
            position.x += horizontal * speed * Time.deltaTime;     //Walk
        }
        transform.position = position;

        //Jump
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerBody.AddForce(new Vector2(0f, 1.2f*jumpForce), ForceMode2D.Impulse);    //Running Jump
            }
            else
            {
                playerBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);         //Walking Jump
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void PlayerAnimation(float horizontal)
    {
        if (Input.GetKey(KeyCode.LeftShift))                          // For Run animation, I make speed variable > 1.99, Pressing L.Shift
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
        bool crouch = (Input.GetKey(KeyCode.LeftControl)) || (Input.GetKey(KeyCode.RightControl));
        animator.SetBool("Crouch", crouch);

        if (crouch)
        {
            playerCollider.size = new Vector2(0.9f, 1.3f);
            playerCollider.offset = new Vector2(-0.12f, 0.6f);
        }

        //Jump Animation

        bool jumped = (Input.GetButtonDown("Jump"));
        animator.SetBool("Jumped", jumped);
        animator.SetBool("isGrounded", isGrounded);
    }
}
