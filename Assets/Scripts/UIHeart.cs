using UnityEngine;

public class UIHeart : MonoBehaviour
{
    private bool one, two, three;

    private void Start()
    {
        HeartController();
    }
    public void HeartController(int heartCount = 3)
    {
        Debug.Log("Heart");
        bool one = (heartCount >=1) ? true : false;
        bool two = (heartCount >= 2) ? true : false;
        bool three = (heartCount >= 3) ? true : false;

        GameObject.Find("fullHeart1").SetActive(three);
        GameObject.Find("emptyHeart1").SetActive(!three);
        GameObject.Find("fullHeart2").SetActive(two);
        GameObject.Find("emptyHeart2").SetActive(!two);
        GameObject.Find("fullHeart3").SetActive(one);
        GameObject.Find("emptyHeart3").SetActive(!one);
    }
}
