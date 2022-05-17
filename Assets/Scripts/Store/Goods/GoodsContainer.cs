using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class GoodsData
{
    public GoodsData(string _name, int _level)
    {
        goodsName = _name;
        goodsLevel = _level;
    }

    public string goodsName;       //��ǰ �̸�
    public int goodsLevel;         //��ǰ ����
}

public class GoodsContainer
{
    public GoodsContainer()
    {
        resetGoodsData();
    }

    public int goodsCount;  //��ǰ(��������) ���� ����
    public GoodsData[] goodsList;  //��ǰ(�������� ���� ����Ʈ)

    public void resetGoodsData()
    {
        goodsCount = 4; //��ǰ�� ���� *����Ʈ�ڵ����� ������ �������� ���..

        goodsList = new GoodsData[goodsCount];

        goodsList[0] = new GoodsData("Rack", 0);
        goodsList[1] = new GoodsData("Vase", 0);
        goodsList[2] = new GoodsData("Box", 0);
        goodsList[3] = new GoodsData("Thread", 0);
    }
}
