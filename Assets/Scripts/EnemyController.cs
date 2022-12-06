using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D enemyCollider;
    PlayerController playercontroller;

    private void Start()
    {
        enemyCollider = gameObject.GetComponent<BoxCollider2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            playercontroller = collision.gameObject.GetComponent<PlayerController>();
            playercontroller.EnemyCollider();
            Animator heartanim = GameObject.FindWithTag("Heart").GetComponent<Animator>();
            heartanim.SetTrigger("heartBreak");
            Destroy(GameObject.FindWithTag("Heart"), 0.5f);
        }
    }
}
