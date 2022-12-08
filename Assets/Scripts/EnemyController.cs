using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D enemyCollider;
    PlayerController playercontroller;

    private int speed = 2;
    bool flipped = false;

    private void Start()
    {
        enemyCollider = gameObject.GetComponent<BoxCollider2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            playercontroller = collision.gameObject.GetComponent<PlayerController>();
            playercontroller.EnemyCollider();
            Animator heartanim = GameObject.FindWithTag("Heart").GetComponent<Animator>();
            heartanim.SetTrigger("heartBreak");
            Destroy(GameObject.FindWithTag("Heart"), 0.5f);
        }

        if (collision.gameObject.CompareTag("WayPoint"))
        {
            //Flip the enemy
            if (flipped == false)
            {
                flipped = true;
                Vector3 scale = transform.localScale;
                scale.x = -1f * scale.x;
                transform.localScale = scale;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WayPoint"))
        {
            flipped = false;
        }
    }
    private void Update()
    {
        //Move in the direction that it is facing
        Vector3 Lscale = transform.localScale;
        Vector3 position = transform.position;
        speed = (Lscale.x > 0f) ? Mathf.Abs(speed) : (-1* Mathf.Abs(speed));
        position.x += speed * Time.deltaTime;
        transform.position = position;
    }


}
