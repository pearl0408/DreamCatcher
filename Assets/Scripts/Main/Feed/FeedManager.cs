using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedManager : MonoBehaviour
{
    // ���̸� �����ϴ� Ŭ����

    [Header("Feed Setting")]
    [SerializeField] private int numberOfFeed = 4;      //�� ���� ���� 
    [SerializeField] private bool isSelected;   //���� ���� ���� ����
    [SerializeField] private int selectedFeedNum;       //���õ� ���� ��ȣ
    [SerializeField] private int selectedBirdNum;       //���õ� �� ��ȣ

    public void Start()
    {

        //isSelected = false;
        this.GetComponent<FeedTimer>().LoadFeedSaveData();  //���� ���� ������ �о��
    }


    public int GetNumberOfFeed()
    {
        //�� ���� ������ ��ȯ�ϴ� �Լ�

        return numberOfFeed;
    }

    public bool GetIsFeedSelected()
    {
        //���� ���� ���θ� ��ȯ�ϴ� �Լ�

        return isSelected;
    }

    public void SetIsFeedSelected(bool TorF)
    {
        //���� ���� ���θ� �����ϴ� �Լ�

        this.isSelected = TorF;
        this.gameObject.GetComponent<FeedTimer>().SetIsFeedSelected(TorF);      //Ÿ�̸� Ŭ������ ���� ���� ���ε� ����
    }

    public int GetSelectedFeedNum()
    {
        //���õ� ���� ��ȣ�� ��ȯ�ϴ� �Լ�

        return selectedFeedNum;
    }

    public void SetSelectedFeedNum(int num)
    {
        //���õ� ���� ��ȣ�� �����ϴ� �Լ�

        selectedFeedNum = num;
    }

    public int GetSelectedBirdNum()
    {
        //���õ� ���� ��ȣ�� ��ȯ�ϴ� �Լ�

        return selectedBirdNum;
    }

    public void SetSelectedBirdNum(int num)
    {
        //���õ� ���� ��ȣ�� �����ϴ� �Լ�

        selectedBirdNum = num;
    }
}
