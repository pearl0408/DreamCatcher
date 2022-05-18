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
        // ������ ǥ�� �� ��� �ʱ�ȭ (num==0)
        circles[num].sprite = circleRed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ������ ȭ��ǥ Ŭ��
    public void ArrowRight()
    {
        if(num>=0&&num<3)
        {
            // ������ ǥ�� �� ��� ����
            circles[num].sprite = circleGray;
            num++;
            circles[num].sprite = circleRed;

            //��ũ�� �� �̵�
            gameObject.transform.localPosition = new Vector2(-1451.8f * num, 0);
        }      
    }

    // ���� ȭ��ǥ Ŭ��
    public void ArrowLeft()
    {
        if(num>0&&num<=3)
        {
            // ������ ǥ�� �� ��� ����
            circles[num].sprite = circleGray;
            num--;
            circles[num].sprite = circleRed;

            // ��ũ�� �� �̵�
            gameObject.transform.localPosition = new Vector2(-1451.8f * num, 0);
        }
    }
}
