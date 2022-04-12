using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FeedRackMatch : MonoBehaviour
{
    //���� �巡�� �̺�Ʈ�� Ƚ�� ���̸� �����ϴ� Ŭ����

    [Header("Feed Objects")]
    [SerializeField] private GameObject[] FeedObj;     //�巡�� �̺�Ʈ �߰��� ���� ������Ʈ �迭
    [SerializeField] private GameObject[] RackFeedObj;     //Ƚ���� ���� ������Ʈ �迭
    [SerializeField] private GameObject Feed_Panel;     //���� �г�

    private int numberOfFeed;     //���� ���� 
    private bool isSelected;     //���� ���� ���� ����
    //private int selectNum;     //������ ���� ��ȣ
    private GameObject feedManager;
    private GameObject feedTimer;

    private void Start()
    {
        feedManager = GameObject.FindGameObjectWithTag("FeedManager");
        feedTimer = GameObject.FindGameObjectWithTag("FeedManager");

        numberOfFeed = feedManager.GetComponent<FeedManager>().GetNumberOfFeed();   //���� �� ���� ������
        isSelected = feedManager.GetComponent<FeedManager>().IsFeedSelected(); //���� ���� ���� ������

        for (int i = 0; i < numberOfFeed; i++)
        {
            SetFeedNum(FeedObj[i].gameObject, i);  //���� ������Ʈ�� ���� ��ȣ ����

            //���� ���� ��ư �̺�Ʈ �߰�
            //���̸� �����ϸ� 1. ���� ��ȣ ������, 2. ���̸� Ƚ�뿡 ����
            //int index = i;          //���� ��ȣ �����ϴ� �ε���(i�� �ٷ� ������ ������)
            //FeedObj[i].onClick.AddListener(delegate { GetFeedNum(index); SelectFeed(); });
            //
            //�巡�� �̺�Ʈ �߰�
            //�巡�� �ؼ� ���� ��ġ�� ������ 1. ���� ��ȣ ������, 2. ���̸� Ƚ�뿡 ����
        }
    }


    private void SetFeedNum(GameObject obj, int num)
    {
        //���� ������Ʈ�� ���� ��ȣ �����ϴ� �Լ�

        obj.GetComponent<FeedInfo>().SetFeedNumber(num);
    }

/*    private void GetFeedNum(int num)
    {
        //���� ������Ʈ�� ���� ��ȣ ��ȯ�ϴ� �Լ�

        this.selectNum = FeedObj[num].gameObject.GetComponent<FeedInfo>().GetFeedNumber();
    }*/

    public void SelectFeed(int feedNum)
    {
        //���̸�  �����ϴ� �Լ�

        //int feedNum = selectNum;    //���� ���� ��ȣ ��������

        if (!isSelected)    //���� ���õ� ���̰� ���ٸ�
        {
            SetActiveRackFeed(feedNum);     //Ƚ�� ���� Ȱ��ȭ
            isSelected = true;          
            feedManager.GetComponent<FeedManager>().SetIsFeedSelected(isSelected);  //���� ���� ���� ����
            feedTimer.GetComponent<FeedTimer>().SetFeedStartTime();   //���� ���� �ð� ����

            SetInActiveFeedingPanel();  //�г� ����
        }
    }

    private void SetActiveRackFeed(int num)
    {
        //Ƚ���� ���̸� Ȱ��ȭ�ϴ� �Լ�

        RackFeedObj[num].SetActive(true);
    }

    private void SetInActiveFeedingPanel()
    {
        //���� ���� �г��� ��Ȱ��ȭ�ϴ� �Լ�

        Feed_Panel.SetActive(false);
    }
}
