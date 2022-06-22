using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainProducts : MonoBehaviour
{
    [Header("[Good Objects]")]
    public Image[] goodsContents;   //��ǰ ������Ʈ �迭(�̹��� ������ ���� �̹�����)
    public SpriteArray[] goodsImages; //��ǰ �̹��� �迭

    private GoodsContainer curGoodsData;   //�÷��̾��� ����� ��ǰ ���� ����

    private void Start()
    {
        ResetMainProducts(); //��ǰ ���� ������Ʈ
    }

    public void ResetMainProducts()
    {
        //��ǰ�� �̹����� �ҷ����� �Լ�

        GameManager.instance.ResetGameManager();    //���� ������ ����
        curGoodsData = GameManager.instance.loadGoodsData;  //���� ������ ��������

        for (int i = 0; i < curGoodsData.goodsCount; i++)
        {
            int goodsLevel = curGoodsData.goodsList[i].goodsLevel;  //��ǰ ����
            goodsContents[i].gameObject.GetComponent<Image>().sprite = goodsImages[i].imageList[goodsLevel]; //��ǰ �̹��� �ҷ���
        }
    }
}
