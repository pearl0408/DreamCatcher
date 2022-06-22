using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedManager : MonoBehaviour
{
    // ���̸� �����ϴ� Ŭ����

    [Header("[Feed Setting]")]
    [SerializeField] private bool isSelected;   //���� ���� ���� ����
    [SerializeField] private int selectedFeedNum;       //���õ� ���� ��ȣ
    [SerializeField] private int selectedBirdNum;       //���õ� �� ��ȣ

    public void Start()
    {
        this.GetComponent<FeedTimer>().LoadTimerData();  //Ÿ�̸�(���� ����) ���� ������ �о��
    }

    public void SetFeedManager(bool _isSelected, int _selectedFeedNum, int _selectedBirdNum)
    {
        //FeedManager �����͸� �� ���� �����ϴ� �Լ�

        isSelected = _isSelected;
        selectedFeedNum = _selectedFeedNum;
        selectedBirdNum = _selectedBirdNum;
    }

    public bool GetIsFeedSelected()
    {
        //���� ���� ���θ� ��ȯ�ϴ� �Լ�

        return isSelected;
    }

    public void SetIsFeedSelected(bool TorF)
    {
        //���� ���� ���θ� �����ϴ� �Լ�

        isSelected = TorF;
        //this.gameObject.GetComponent<FeedTimer>().SetIsFeedSelected(TorF);      //Ÿ�̸� Ŭ������ ���� ���� ���ε� ����
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
