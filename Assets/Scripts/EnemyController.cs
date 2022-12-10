using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D enemyCollider;
    PlayerController playercontroller;

    private int enemySpeed = 2;
    bool flipped = false;

    private void Start()
    {
        enemyCollider = gameObject.GetComponent<BoxCollider2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            playercontroller = collision.gameObject.GetComponent<PlayerController>();
            playercontroller.EnemyCollider();
            Animator heartanim = GameObject.FindWithTag("Heart").GetComponent<Animator>();
            heartanim.SetTrigger("heartBreak");
            Destroy(GameObject.FindWithTag("Heart"), 0.5f);
        }
    }
    private void Update()
    {
        //Move in the direction that it is facing
        Vector3 Lscale = transform.localScale;
        Vector3 position = transform.position;
        enemySpeed = (Lscale.x > 0f) ? Mathf.Abs(enemySpeed) : (-1* Mathf.Abs(enemySpeed));
        position.x += enemySpeed * Time.deltaTime;
        transform.position = position;
    }


}
