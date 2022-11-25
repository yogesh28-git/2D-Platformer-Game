using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    BoxCollider2D playerCollider;
    void Awake()
    {
        Debug.Log("Script detected !!!");
    }
    private void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();

    }

    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        if(Input.GetKey(KeyCode.LeftShift))                          // For Run animation, I make speed variable > 1.99, Pressing L.Shift
        {
            speed = 2 * speed;
        }
        animator.SetFloat("Speed", Mathf.Abs(speed));                          
        animator.SetBool("Walk_Button", (speed != 0 ? true : false));
        

        //Flipping the player 
        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if(speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        //Crouch
        bool crouch = (Input.GetKey(KeyCode.LeftControl)) || (Input.GetKey(KeyCode.RightControl));
        animator.SetBool("Crouch", crouch);

        if (crouch)
        {
            playerCollider.size = new Vector2(0.9f, 1.3f);
            playerCollider.offset = new Vector2(-0.12f, 0.6f);
        }

        bool jumped = (Input.GetKeyDown(KeyCode.Space));
        if (!animator.GetBool("Jumped"))
        {
            animator.SetBool("Jumped", jumped);
        }
        else
        {
            animator.SetBool("Jumped", false);
        }
        
    }
}
