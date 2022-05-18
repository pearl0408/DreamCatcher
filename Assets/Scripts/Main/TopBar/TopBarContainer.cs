using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class TopBarData
{
    public TopBarData(string _name, int _number)
    {
        dataName = _name;
        dataNumber = _number;
    }

    public string dataName;       //��ǰ �̸�
    public int dataNumber;         //��ǰ ����
}

public class TopBarContainer
{
    public TopBarContainer()
    {
        ResetTopBarData();
    }

    public int dataCount;   //������ ���� ����
    public TopBarData[] dataList;   //��ܹ� ������ ����Ʈ(�ޱ���, ���, Ư������)

    public void ResetTopBarData()
    {
        dataCount = 3;  //����Ʈ�ڵ����� ���� �������� ���

        dataList = new TopBarData[dataCount];

        dataList[0] = new TopBarData("DreamMarble", 0);
        dataList[1] = new TopBarData("Gold", 30000);
        dataList[2] = new TopBarData("SpecialFeed", 5);
    }
}
