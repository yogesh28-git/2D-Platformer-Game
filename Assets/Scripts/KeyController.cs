using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    PlayerController playercontroller;
    private int keyPoints = 10;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            playercontroller = collision.gameObject.GetComponent<PlayerController>();
            playercontroller.pickupKey(keyPoints);
            Destroy(gameObject);
        }
    }
}
