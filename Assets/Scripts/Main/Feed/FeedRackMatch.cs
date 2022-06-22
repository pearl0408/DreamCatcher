using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FeedRackMatch : MonoBehaviour
{
    //���� �巡�� �̺�Ʈ�� Ƚ�� ���̸� �����ϴ� Ŭ����

    [Header("[Feed Objects]")]
    public GameObject[] FeedObj;     //�巡�� �̺�Ʈ �߰��� ���� ������Ʈ �迭
    public GameObject[] RackFeedObj;     //Ƚ���� ���� ������Ʈ �迭


    private void Start()
    {
        int numberOfFeed = 4;   //���� �� ����
        for (int i = 0; i < numberOfFeed; i++)
        {
            FeedObj[i].gameObject.GetComponent<FeedInfo>().SetFeedNumber(i);    //���� ������Ʈ�� ���� ��ȣ ����
        }
    }

    public void SelectFeed(int feedNum)
    {
        //���̸� �����ϴ� �Լ�

        bool isSelected = this.gameObject.GetComponent<FeedManager>().GetIsFeedSelected(); //���� ���� ���� ������
        if (!isSelected)    //���� ���õ� ���̰� ���ٸ�
        {
            SetActiveRackFeed(feedNum);     //Ƚ�� ���� Ȱ��ȭ        
            this.gameObject.GetComponent<FeedPanel>().ActiveFeedPanel(false);    //���� �г��� ����
        }
    }

    private void SetActiveRackFeed(int num)
    {
        //Ƚ���� ���̸� Ȱ��ȭ�ϴ� �Լ�

        RackFeedObj[num].SetActive(true);
    }

    public void SetInactiveRackFeed(int num)
    {
        //Ƚ���� ���̸� ��Ȱ��ȭ �ϴ� �Լ�

        RackFeedObj[num].SetActive(false);
    }
}
