using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedManager : MonoBehaviour
{
    // ���̸� �����ϴ� Ŭ����

    [Header("Feed Setting")]
    [SerializeField] private int numberOfFeed = 4;     //���� ���� 
    [SerializeField] private bool isSelected = false;     //���� ���� ���� ����

    public void Start()
    {
        //���� ������ �о��
        //���� ���� ���� ���� �о��
    }


    public int GetNumberOfFeed()
    {
        //�� ���� ������ ��ȯ�ϴ� �Լ�

        return numberOfFeed;
    }

    public bool IsFeedSelected()
    {
        //���� ���� ���θ� ��ȯ�ϴ� �Լ�

        return isSelected;
    }

    public void SetIsFeedSelected(bool TorF)
    {
        //���� ���� ���θ� �����ϴ� �Լ�

        this.isSelected = TorF;
        GameObject.FindGameObjectWithTag("FeedManager").GetComponent<FeedTimer>().UpdateIsFeedSelected();    //Ÿ�̸ӿ� ���� ��ȣ ����
    }

    //���� ���� ����, � ���̸� �����ߴ��� ��ȣ, ���� ���� �ð� ������ ����, �ε�?
}
