using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedInfo : MonoBehaviour
{
    //���� ���� Ŭ����

    [Header("Feed Information")]
    [SerializeField] private int feedNumber;    //���� ��ȣ
    //[SerializeField] private int NumberOfFeed;    //���� ȣ��� Ƚ��?(�Ŀ� ���� �� �� ������� ���� ���� �����ص� �����ҵ�)


    public void SetFeedNumber(int num)
    {
        this.feedNumber = num;
    }

    public int GetFeedNumber()
    {
        return this.feedNumber;
    }
}
