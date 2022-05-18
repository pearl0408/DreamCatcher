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

    public string dataName;       //상품 이름
    public int dataNumber;         //상품 레벨
}

public class TopBarContainer
{
    public TopBarContainer()
    {
        ResetTopBarData();
    }

    public int dataCount;   //데이터 종류 개수
    public TopBarData[] dataList;   //상단바 데이터 리스트(꿈구슬, 골드, 특제먹이)

    public void ResetTopBarData()
    {
        dataCount = 3;  //소프트코딩으로 수정 가능할지 고민

        dataList = new TopBarData[dataCount];

        dataList[0] = new TopBarData("DreamMarble", 0);
        dataList[1] = new TopBarData("Gold", 30000);
        dataList[2] = new TopBarData("SpecialFeed", 5);
    }
}
