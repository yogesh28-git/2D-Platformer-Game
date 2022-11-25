using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    void Awake()
    {
        Debug.Log("Script detected !!!");
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
        Debug.Log("Speed: "+ speed);

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
    }
}
