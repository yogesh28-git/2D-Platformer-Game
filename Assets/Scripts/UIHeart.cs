using System;
using UnityEngine;

public class UIHeart : MonoBehaviour
{
    private bool one, two, three;
    private bool animationStop = false;
    private float timer;

    private GameObject fullHeart1;
    private GameObject fullHeart2;
    private GameObject fullHeart3;
    private GameObject emptyHeart1;
    private GameObject emptyHeart2;
    private GameObject emptyHeart3;

    private Animator heartAnim;
    private RectTransform heartTransform;

    private void Start()
    {
        fullHeart1 = GameObject.Find("fullHeart1");
        fullHeart2 = GameObject.Find("fullHeart2");
        fullHeart3 = GameObject.Find("fullHeart3");
        emptyHeart1 = GameObject.Find("emptyHeart1");
        emptyHeart2 = GameObject.Find("emptyHeart2");
        emptyHeart3 = GameObject.Find("emptyHeart3");
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

        
        /*fullHeart1.SetActive(three);
        emptyHeart1.SetActive(!three);
        fullHeart2.SetActive(two);
        emptyHeart2.SetActive(!two);
        fullHeart3.SetActive(one);
        emptyHeart3.SetActive(!one);*/
    }

    private void Update()
    {
       if(three == false && animationStop == false)
        {
            heartBrokeAnimation(fullHeart1);
        }
        
    }

    private void heartBrokeAnimation(GameObject heartObj)
    {
        heartAnim = heartObj.GetComponent<Animator>();
        heartTransform = heartObj.GetComponent<RectTransform>();
        //heartObj.transform.Translate(new Vector3(0,0,0), Space.World);
        timer += Time.deltaTime;
        if(timer >= 1f)
        {
            heartAnim.SetTrigger("HeartBroken");
        }
        if(timer >= 2.5f)
        {
            animationStop = true;
            fullHeart1.SetActive(false);
        }
         
    }
}
