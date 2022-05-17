using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialFeed : MonoBehaviour
{
    //����� ���� ������ �����ϰ� ����ϴ� Ŭ����

    [Header("Special Feed")]
    [SerializeField] private int feedCount;    //Ư�� ���� ����
    [SerializeField] private int selectCount;    //������ ���� ��
    [SerializeField] private float decreaseTime;   //���ҽ�Ű�� �ð�

    [Space]
    [Header("Feed Text")]
    [SerializeField] private Text countText;      //���� ���� �ؽ�Ʈ

    void Start()
    {
        feedCount = GameManager.instance.specialFeedCount;  //Ư�� ���� ������ ������
        selectCount = 0;
        decreaseTime = 5;   //*Ư������ ���� �ð��� ���� ������ ����

        countText.text = selectCount + "��";
    }

    public void LeftButton()
    {
        //Ư�� ���� ���� �гο��� ���� ���� ���� �Լ�

        if (selectCount > 1)
        {
            selectCount--;
            countText.text = selectCount + "��";
        }
    }

    public void RightButton()
    {
        //Ư�� ���� ���� �гο��� ���� ���� ���� �Լ�

        if (selectCount < feedCount)
        {
            selectCount++;
            countText.text = selectCount + "��";
        }
    }

    public void selectSpecialFeed()
    {
        if (feedCount >= selectCount)
        {
            float decrease = (float)selectCount * decreaseTime;     //Ư�� ���� ������� �����ϴ� �ð� ���
            this.gameObject.GetComponent<FeedTimer>().UseSpecialFeed(decrease);     //Ư�� ���� ���(���� �ð� ����)

            feedCount = feedCount - selectCount;    //Ư�� ���� ���� ����
            GameManager.instance.specialFeedCount = feedCount;

            selectCount = 0;        //������ ���� ���� ����
            countText.text = selectCount + "��";

            GameObject.FindGameObjectWithTag("GameManager").GetComponent<TopBarText>().SetSpecialFeedText(feedCount);   //��ܹ� Ư�� ���� ���� ����
        }
    }
}
