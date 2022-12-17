using UnityEngine;

public class CollectiblesController : MonoBehaviour
{
    PlayerController playercontroller;
    private int keyPoints = 10;
    private Vector3 pos;
    bool triggered = false;

    private void Start()
    {
        pos = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            playercontroller = collision.gameObject.GetComponent<PlayerController>();
            if (gameObject.CompareTag("Key"))
            {
                playercontroller.pickupKey(keyPoints);
            }
            if (gameObject.CompareTag("Heart"))
            {
                playercontroller.heartIncrease(true);
            }
            triggered = true;
            Destroy(gameObject, 0.5f);
        }
    }
    private void Update()
    {
        if (triggered)   // Key Pickup effect: Key will go up and then get destroyed after 0.5 seconds
        {
            pos.y += 0.02f;
            transform.position = pos;
        }
    }

}
