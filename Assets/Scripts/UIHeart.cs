using System;
using UnityEngine;

public class UIHeart : MonoBehaviour
{
    private bool one, two, three;

    private GameObject fullHeart1;
    private GameObject fullHeart2;
    private GameObject fullHeart3;
    private GameObject emptyHeart1;
    private GameObject emptyHeart2;
    private GameObject emptyHeart3;

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
        bool one = (heartCount >= 1) ? true : false;
        bool two = (heartCount >= 2) ? true : false;
        bool three = (heartCount >= 3) ? true : false;

        Debug.Log(one);
        Debug.Log(two);
        Debug.Log(three);
        fullHeart1.SetActive(three);
        emptyHeart1.SetActive(!three);
        fullHeart2.SetActive(two);
        emptyHeart2.SetActive(!two);
        fullHeart3.SetActive(one);
        emptyHeart3.SetActive(!one);
    }
}
