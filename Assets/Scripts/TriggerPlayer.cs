using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerPlayer : MonoBehaviour
{
    private BoxCollider2D door;
    // Start is called before the first frame update
    void Start()
    {
        door = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
