using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionArrow : MonoBehaviour
{
    public Sprite circleRed;
    public Sprite circleGray;
    public Image[] circles;
    public int num=0;

    // Start is called before the first frame update
    void Start()
    {
        circles[num].sprite = circleRed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ArrowRight()
    {
        if(num>=0&&num<3)
        {
            circles[num].sprite = circleGray;
            num++;
            circles[num].sprite = circleRed;

            gameObject.transform.localPosition = new Vector2(-1451.8f * num, 0);
        }      
    }

    public void ArrowLeft()
    {
        if(num>0&&num<=3)
        {
            circles[num].sprite = circleGray;
            num--;
            circles[num].sprite = circleRed;
            gameObject.transform.localPosition = new Vector2(-1451.8f * num, 0);
        }
    }
}
