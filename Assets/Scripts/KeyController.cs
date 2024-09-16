using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
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
            playercontroller.pickupKey(keyPoints);
            triggered = true;
            Destroy(gameObject,0.5f);
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
