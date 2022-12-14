using System;
using UnityEngine;

public class UIHeart : MonoBehaviour
{
    private bool one, two, three;
    private float timer = 0;

    private GameObject fullHeart1;
    private GameObject fullHeart2;
    private GameObject fullHeart3;
    private GameObject emptyHeart1;
    private GameObject emptyHeart2;
    private GameObject emptyHeart3;

    private Vector3 heart1Pos;
    private Vector3 heart2Pos;
    private Vector3 heart3Pos;

    private Animator heartAnim;
    private RectTransform heartTransform;
    private Vector3 midPos = new Vector3 (960f, 890f, 0f);

    private void Start()
    {
        fullHeart1 = GameObject.Find("fullHeart1");
        fullHeart2 = GameObject.Find("fullHeart2");
        fullHeart3 = GameObject.Find("fullHeart3");
        emptyHeart1 = GameObject.Find("emptyHeart1");
        emptyHeart2 = GameObject.Find("emptyHeart2");
        emptyHeart3 = GameObject.Find("emptyHeart3");

        heart1Pos = fullHeart1.transform.position;
        heart2Pos = fullHeart2.transform.position;
        heart3Pos = fullHeart3.transform.position;

        HeartController(3);
    }
    public void HeartController(int heartCount)
    {
        Debug.Log("Heart = "+ heartCount);
        one = (heartCount >= 1) ? true : false;
        two = (heartCount >= 2) ? true : false;
        three = (heartCount >= 3) ? true : false;
        
        Debug.Log(one);
        Debug.Log(two);
        Debug.Log(three);

        emptyHeart1.SetActive(!three);
        emptyHeart2.SetActive(!two);
        emptyHeart3.SetActive(!one);

        
        if (three)
        {
            fullHeart1.transform.position = heart1Pos;
            fullHeart1.transform.localScale = new Vector3(1f, 1f, 1f);
            fullHeart1.SetActive(true); 
        }
        if (two)
        {
            fullHeart2.transform.position = heart2Pos;
            fullHeart2.transform.localScale = new Vector3(1f, 1f, 1f);
            fullHeart2.SetActive(true);
        }
        if (one)
        {
            fullHeart3.transform.position = heart3Pos;
            fullHeart3.transform.localScale = new Vector3(1f, 1f, 1f);
            fullHeart3.SetActive(true);
        }
    }

    private void Update()
    {
        if (three == false && fullHeart1.activeInHierarchy)
        {
            heartEffect(fullHeart1);
        }
        
       if (two == false && fullHeart2.activeInHierarchy)
       {
            heartEffect(fullHeart2);
       }
       if (one == false && fullHeart3.activeInHierarchy)
       {
            heartEffect(fullHeart3);
       }
        
    }

    private void heartEffect(GameObject heartObj)
    {
        heartAnim = heartObj.GetComponent<Animator>();
        heartTransform = heartObj.GetComponent<RectTransform>();
        timer += Time.deltaTime;
        heartTransform.position = Vector3.MoveTowards(heartTransform.position, midPos, timer * 20);
        if(timer >= 0.5f)
        {
            heartAnim.SetTrigger("HeartBroken");
        }
        if(timer >= 1.5f)
        {
            Debug.Log(heartObj.name);
            timer = 0;
            heartObj.SetActive(false);
        }
         
    }
}
